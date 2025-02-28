using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace UnderWalls_NM
{
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;
        public const uint PROCESS_VM_OPERATION = 0x0008;

        private IntPtr hProcess;
        private Process? targetProcess;
        private CancellationTokenSource? staminaCts;
        private CancellationTokenSource? godModeCts;
        private const string TARGET_PROCESS = "ProjetCoopHorreur-Win64-Shipping"; // Le nom du .exe que tu l'app dois target 
        private const string DISCORD_URL = "https://discord.gg/qfjcts7MZx"; // Le lien discord pour la MainPage 
        private bool isRunning = true;
        private DateTime lastUpdateTime;
        private bool isEditingMoney = false;

        private struct MemoryValue
        {
            public IntPtr BaseAddress;
            public int[] Offsets;
            public int Size;
        }

        private MemoryValue moneyValue;
        private MemoryValue staminaValue;
        private MemoryValue godModeValue;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMemoryValues();
            SetupEventHandlers();
            DisableControls();
            StartProcessCheck();
        }

        private void InitializeMemoryValues()
        {
            moneyValue = new MemoryValue { Size = 8, Offsets = new int[] { 0x80, 0x2E0, 0x2A8, 0xB0, 0xA0, 0x80, 0x330 } };
            staminaValue = new MemoryValue { Size = 4, Offsets = new int[] { 0x3C0, 0x50, 0x708, 0x548, 0x2B8, 0x18, 0x5E4 } };
            godModeValue = new MemoryValue { Size = 8, Offsets = new int[] { 0x30, 0x340, 0x50, 0x278, 0x8, 0x90, 0x750 } };
        }

        private void DisableControls()
        {
            MoneyTextBox.IsEnabled = false;
            SetMoneyButton.IsEnabled = false;
            StaminaToggle.IsEnabled = false;
            GodModeToggle.IsEnabled = false;
        }

        private void EnableControls()
        {
            MoneyTextBox.IsEnabled = true;
            SetMoneyButton.IsEnabled = true;
            StaminaToggle.IsEnabled = true;
            GodModeToggle.IsEnabled = true;
        }

        private void SetupEventHandlers()
        {
            SetMoneyButton.Click += SetMoneyButton_Click;
            StaminaToggle.Checked += StaminaToggle_Checked;
            StaminaToggle.Unchecked += StaminaToggle_Unchecked;
            GodModeToggle.Checked += GodModeToggle_Checked;
            GodModeToggle.Unchecked += GodModeToggle_Unchecked;
            
            MoneyTextBox.TextChanged += (s, e) => isEditingMoney = true;
            SetMoneyButton.Click += (s, e) => isEditingMoney = false;
            
            Closed += (s, e) => 
            {
                isRunning = false;
                staminaCts?.Cancel();
                godModeCts?.Cancel();
                if (hProcess != IntPtr.Zero)
                    CloseHandle(hProcess);
            };

            DiscordButton.Click += DiscordButton_Click;
        }

        private async void StartProcessCheck()
        {
            while (isRunning)
            {
                Process[] processes = Process.GetProcessesByName(TARGET_PROCESS);
                if (processes.Length > 0)
                {
                    targetProcess = processes[0];
                    InitializeProcess();
                    break;
                }
                await Task.Delay(1000);
            }
        }

        private void InitializeProcess()
        {
            if (targetProcess == null) return;

            hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, targetProcess.Id);
            
            if (hProcess != IntPtr.Zero)
            {
                Dispatcher.Invoke(() =>
                {
                    StatusText.Text = "Jeu connecté !";
                    StatusText.Foreground = new SolidColorBrush(Color.FromRgb(0, 168, 107));

                    // Initialiser les adresses de base
                    moneyValue.BaseAddress = targetProcess.MainModule?.BaseAddress + 0x074F8260 ?? IntPtr.Zero;
                    staminaValue.BaseAddress = targetProcess.MainModule?.BaseAddress + 0x07476650 ?? IntPtr.Zero;
                    godModeValue.BaseAddress = targetProcess.MainModule?.BaseAddress + 0x0786E620 ?? IntPtr.Zero;

                    // Mettre à jour les informations
                    ProcessIdText.Text = $"PID : {targetProcess.Id}";
                    UpdateLastUpdateTime();

                    // Activer les contrôles
                    EnableControls();
                });

                // Commencer à mettre à jour l'affichage de l'argent
                StartMoneyUpdateLoop();
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Impossible de se connecter au jeu.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void UpdateLastUpdateTime()
        {
            lastUpdateTime = DateTime.Now;
            LastUpdateText.Text = $"Dernière mise à jour : {lastUpdateTime:HH:mm:ss}";
        }

        private async void StartMoneyUpdateLoop()
        {
            while (isRunning)
            {
                UpdateMoneyDisplay();
                await Task.Delay(1000);
            }
        }

        private void UpdateMoneyDisplay()
        {
            if (isEditingMoney) return;
            
            byte[] buffer = new byte[moneyValue.Size];
            if (ReadValue(moneyValue, buffer))
            {
                double money = BitConverter.ToDouble(buffer, 0);
                Dispatcher.Invoke(() =>
                {
                    MoneyTextBox.Text = money.ToString("F0");
                    UpdateLastUpdateTime();
                });
            }
        }

        private void SetMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(MoneyTextBox.Text, out double newMoney))
            {
                byte[] buffer = BitConverter.GetBytes(newMoney);
                if (WriteValue(moneyValue, buffer))
                {
                    StatusText.Text = "Argent modifié avec succès !";
                    UpdateLastUpdateTime();
                }
            }
        }

        private async void StaminaToggle_Checked(object sender, RoutedEventArgs e)
        {
            staminaCts = new CancellationTokenSource();
            await RunStaminaLoop(staminaCts.Token);
        }

        private void StaminaToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            staminaCts?.Cancel();
        }

        private async void GodModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            godModeCts = new CancellationTokenSource();
            await RunGodModeLoop(godModeCts.Token);
        }

        private void GodModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            godModeCts?.Cancel();
        }

        private async Task RunStaminaLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && isRunning)
                {
                    WriteValue(staminaValue, BitConverter.GetBytes(100.0f));
                    await Task.Delay(100, token);
                }
            }
            catch (OperationCanceledException)
            {
                // Annulation normale, on ne fait rien
            }
        }

        private async Task RunGodModeLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && isRunning)
                {
                    WriteValue(godModeValue, BitConverter.GetBytes(100000.0));
                    await Task.Delay(100, token);
                }
            }
            catch (OperationCanceledException)
            {
                // Annulation normale, on ne fait rien
            }
        }

        private bool ReadValue(MemoryValue memVal, byte[] buffer)
        {
            IntPtr address = memVal.BaseAddress;
            byte[] tempBuffer = new byte[8];
            uint bytesRead;

            foreach (int offset in memVal.Offsets)
            {
                if (!ReadProcessMemory(hProcess, address, tempBuffer, (uint)IntPtr.Size, out bytesRead))
                    return false;

                address = IntPtr.Add(new IntPtr(BitConverter.ToInt64(tempBuffer, 0)), offset);
            }

            return ReadProcessMemory(hProcess, address, buffer, (uint)memVal.Size, out bytesRead);
        }

        private bool WriteValue(MemoryValue memVal, byte[] buffer)
        {
            IntPtr address = memVal.BaseAddress;
            byte[] tempBuffer = new byte[8];
            uint bytesRead;

            foreach (int offset in memVal.Offsets)
            {
                if (!ReadProcessMemory(hProcess, address, tempBuffer, (uint)IntPtr.Size, out bytesRead))
                    return false;

                address = IntPtr.Add(new IntPtr(BitConverter.ToInt64(tempBuffer, 0)), offset);
            }

            uint bytesWritten;
            return WriteProcessMemory(hProcess, address, buffer, (uint)buffer.Length, out bytesWritten);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = DISCORD_URL,
                UseShellExecute = true
            });
        }
    }
}
