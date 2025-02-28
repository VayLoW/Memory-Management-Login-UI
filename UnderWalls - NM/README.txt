Trainer UnderWalls - Gestion de la Mémoire, Login & UI
=========================================================================

INFORMATIONS TECHNIQUES :
-----------------------
1. Modification de l'argent :
   - Processus ciblé : ProjetCoopHorreur-Win64-Shipping.exe
   - Module de base : "ProjetCoopHorreur-Win64-Shipping.exe"+074F8260
   - Offsets : 80 -> 2E0 -> 2A8 -> B0 -> A0 -> 80 -> 330
   - Type de donnée : Double (8 octets)

2. Stamina infinie :
   - Module de base : "ProjetCoopHorreur-Win64-Shipping.exe"+07476650
   - Offsets : 3C0 -> 50 -> 708 -> 548 -> 2B8 -> 18 -> 5E4
   - Type de donnée : Float (4 octets)

3. God Mode :
   - Module de base : "ProjetCoopHorreur-Win64-Shipping.exe"+0786E620
   - Offsets : 30 -> 340 -> 50 -> 278 -> 8 -> 90 -> 750
   - Type de donnée : Double (8 octets)

FONCTIONNALITÉS :
---------------
1. Recherche automatique du processus du jeu
2. Lecture de la valeur actuelle de l'argent
3. Modification de l'argent (supporte les décimales)
4. Activation/Désactivation de la stamina infinie
5. Activation/Désactivation du God Mode
6. Interface en français

DÉTAILS TECHNIQUES IMPORTANTS :
----------------------------
1. Utilisation des API Windows :
   - OpenProcess avec PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION
   - ReadProcessMemory
   - WriteProcessMemory
   - CloseHandle

2. Gestion de la mémoire :
   - Argent : buffer de 8 octets (Double)
   - Stamina : buffer de 4 octets (Float)
   - God Mode : buffer de 8 octets (Double)
   - Utilisation de BitConverter pour la conversion des données

3. Fonctionnalités automatiques :
   - Stamina infinie : Maintient la stamina à 100.0
   - God Mode : Maintient la vie à 100000.0
   - Exécution dans des threads séparés
   - Mise à jour toutes les 100ms
   - Arrêt propre des threads à la fermeture

COMMENT UTILISER :
----------------
1. Lancer le jeu
2. Lancer le trainer (UnderWalls - NM.exe)
3. Le trainer trouvera automatiquement le jeu
4. Utiliser le menu pour :
   - Option 1 : Voir l'argent actuel
   - Option 2 : Modifier l'argent
   - Option 3 : Activer/Désactiver la stamina infinie
   - Option 4 : Activer/Désactiver le God Mode
   - Option 5 : Quitter

NOTES IMPORTANTES :
-----------------
- Le trainer doit être exécuté en tant qu'administrateur si le jeu l'est
- Les valeurs décimales sont supportées pour l'argent (exemple : 1000.50)
- La stamina infinie et le God Mode utilisent des threads séparés
- Le trainer attend automatiquement que le jeu soit lancé
- Toutes les modifications sont instantanées
- Les threads sont proprement arrêtés à la fermeture du trainer

CODE SOURCE :
-----------
Le code source complet est disponible dans Program.cs
Compilé avec .NET 8.0

PS : Aucun contournement Anti-Cheat n'a été mis en place, c'est uniquement de la lecture et de l'écriture en mémoire.
(Les offsets ne seront pas mis à jour pour le trainer, ce dépôt Git sert uniquement à partager mon système de login (simple) et mon UI/GUI.)

Site code de base : http://51.222.158.82:5000/


