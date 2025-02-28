Memory Management, Login & UI
================================

Un projet éducatif sur la gestion de la mémoire en jeu, un système de login simple et une interface utilisateur (UI/GUI).

----------------------------------------

📌 Fonctionnalités

🎮 Gestion de la mémoire en jeu
- Modification de l'argent (supporte les valeurs décimales)
- Stamina infinie (maintient la stamina à 100.0)
- God Mode (maintient la vie à 100000.0)

🖥️ Fonctionnalités générales
- Détection automatique du processus du jeu
- Interface utilisateur en français
- Mise à jour des valeurs toutes les 100ms
- Exécution multithread pour une gestion fluide

----------------------------------------

⚙️ Détails techniques

🔧 API Windows utilisées
- OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION)
- ReadProcessMemory
- WriteProcessMemory
- CloseHandle

📂 Gestion de la mémoire

Argent:
- Type : Double (8 octets)
- Offsets : 80 -> 2E0 -> 2A8 -> B0 -> A0 -> 80 -> 330

Stamina:
- Type : Float (4 octets)
- Offsets : 3C0 -> 50 -> 708 -> 548 -> 2B8 -> 18 -> 5E4

God Mode:
- Type : Double (8 octets)
- Offsets : 30 -> 340 -> 50 -> 278 -> 8 -> 90 -> 750

Conversion des valeurs via BitConverter pour assurer l'intégrité des données.

----------------------------------------

🔧 Utilisation

1. Lancer le jeu
2. Exécuter le trainer (UnderWalls-NM.exe)
3. Le trainer détecte automatiquement le jeu
4. Utiliser le menu :
   - Voir l'argent actuel
   - Modifier l'argent
   - Activer/Désactiver la stamina infinie
   - Activer/Désactiver le God Mode
   - Quitter proprement

*Important* : Le trainer doit être exécuté en tant qu'administrateur si le jeu l'est aussi.

----------------------------------------

📝 Notes importantes

- Ce projet est à but éducatif. Aucun contournement d'Anti-Cheat n'est mis en place.
- Seules des opérations en mémoire locales sont effectuées via l'API Windows.

📂 Code source disponible dans "MainWindow.xaml.cs"
🌐 Site pour le code par défaut : http://51.222.158.82:5000/


Login :
![image](https://github.com/user-attachments/assets/4b198e15-b187-4c29-bc07-9438d3f01372)


Main Menu : 
![image](https://github.com/user-attachments/assets/b10ab058-fc92-415e-8b39-394cf3c98783)




Mon discord si vous avez des questions : katrevin
