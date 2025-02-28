# Memory-Management-Login-UI
Memory Management, Login &amp; UI partage un système de login, une UI personnalisée et la gestion de la mémoire en jeu via l'API Windows. Lecture/écriture de valeurs comme l’argent, la stamina et la vie, sans contournement Anti-Cheat.

Trainer UnderWalls - Gestion de la Mémoire, Login & UI
📌 Présentation
Ce dépôt a pour but de partager mon système de login (simple), mon interface utilisateur (UI/GUI) et la manière dont j'ai géré la lecture/écriture en mémoire pour un jeu.

🚨 Aucune méthode de contournement Anti-Cheat n'a été mise en place. Ce projet se limite à des opérations en mémoire locales via l'API Windows.

⚙️ Fonctionnalités
🔹 Gestion de la mémoire en jeu
Modification de l'argent (supporte les valeurs décimales)
Stamina infinie (maintient la stamina à 100.0)
God Mode (maintient la vie à 100000.0)
🔹 Fonctionnalités générales
Recherche automatique du processus du jeu
Interface en français
Gestion propre des threads pour la mémoire
Exécution et mise à jour des valeurs toutes les 100ms
🔍 Détails techniques
🛠️ API Windows utilisées
OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION)
ReadProcessMemory
WriteProcessMemory
CloseHandle
📂 Gestion de la mémoire
Fonction	Type de donnée	Offsets utilisés
Argent	Double (8 octets)	80 -> 2E0 -> 2A8 -> B0 -> A0 -> 80 -> 330
Stamina	Float (4 octets)	3C0 -> 50 -> 708 -> 548 -> 2B8 -> 18 -> 5E4
God Mode	Double (8 octets)	30 -> 340 -> 50 -> 278 -> 8 -> 90 -> 750
💡 Conversion des valeurs via BitConverter pour assurer l'intégrité des données.

🖥️ Utilisation
Lancer le jeu
Exécuter le trainer (UnderWalls-NM.exe)
Le trainer détecte automatiquement le jeu
Options disponibles :
📊 Voir l'argent actuel
💰 Modifier l'argent
⚡ Activer/Désactiver la stamina infinie
🛡️ Activer/Désactiver le God Mode
❌ Quitter proprement
🔹 Le trainer doit être lancé en tant qu'administrateur si le jeu l'est.

📜 Code source
compilé avec .NET 8.0.

🌐 Site du code de base : http://51.222.158.82:5000/

📢 Remarque importante
Ce projet n'est pas un cheat et ne contourne aucun système anti-triche. Il sert uniquement à montrer la gestion de la mémoire en lecture/écriture ainsi que mon système de login et d'UI.

Serveur discord:  (https://discord.gg/CJgHWdjyzu)
Discord : katrevin
