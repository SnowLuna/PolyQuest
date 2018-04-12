# Projet de session

Projet de session dans le cadre du cours de INF5071 - Infographie enseigné par Alexandre Blondin Massé
à l'Université du Québec à Montréal. Le but étant de créer un jeu vidéo 3D qui met en pratique les concepts
explorés en classe.

## Membres de l'équipe

Philip D'Costa (DCOP17069401)

## Description du projet

**PolyQuest** est un jeu de rôle (*RPG*) qui est présentement dans la phase prototype. Plusieurs fonctionnalités
et éléments faisant partie de la méchanique de jeu (*gameplay*) sont absents ou encore en développement.

Présentement, à la deuxième présentation, le projet comporte une ile en plein milieu de l'océan sur laquelle se
retrouve un personnage qui s'est échoué. La petite ile comporte plusieurs types de terrains et des objets ramassables
par le joueur. 

L'objectif était de mettre en place un prototype comportant les éléments principaux afin de pourvoir continuer le 
développement facilement. Plusieurs aspects du code et des ressources, on étés pensés et crées avec cette idée de réutilisation
 (*reusable assets*).
 
La direction que le jeu **devait prendre / va prendre** est la suivante: le monde est composé de tuiles carrés représentant soit des iles,
 de l'eau ou encore, d'autres environnements. La possibilité de placer plusieurs tuiles l'une a coté de l'autre afin de former une plus 
 grosse ile. Le joueur commence sur une petite ile (*ile du tutoriel*) qui lui permettra d'apprendre les bases du jeu: soit le mouvement de 
 la caméra, du personnage, l'interaction avec les objets et les personnage non-joueur (*NPC*), utiliser son inventaire, le système de combat, etc.
 Une fois le tutoriel complété, le joueur aura ramassé assez de matériaux afin de réparer son bateau et d'explorer le reste de l'océan.

## Contenu du dépot et fonctionnement

Le dépot git contient le projet Unity du jeu. Par défaut, Unity créer plusieurs dossier dans lesquels il sauvegarde les données générées du projet.
Dans notre cas, les ressources importantes utilisées dans la construction du jeu se retrouvent dans le dossier **Assets**. Le dossier est divisé en plusieurs sous-répertoire 
afin de conserver une certaine structure. 

Il suffit simplement de le télécharger dans son entièreté et de choisir le dossier lorsque l'on importe
dans le moteur de jeu. Une fois dans Unity, dans le dossier **Assets**, sélectionner la scène désirée; par défaut il charge le dernier qui a été ouvert. Pour
construire un exécutable, aller dans **File**, puis appuyer sur **Build Settings**. Une nouvelle fenêtre s'ouvrira; il ne reste qu'à choisir la plateforme sur 
laquelle on veut rouler le jeu, le type de sysème (32 ou 64 bit) et confirmer. 

Une fois l'éxécutable disponible et lancée, nous nous retrouvons sur le menu principal. Celui-ci offre 3 options:
* **Play** (Démarrer une nouvelle partie)
* **Option** (Ajuster des options tel que le volume, ne fonctionne pas présentement car aucun audio)
* **Quit** (Quitter l'application)

Si l'on clique sur *Play*, le jeu chargera une nouvelle scène, celle d'un bonhomme sur une ile. Ici, nous avons plusieurs options:
* **Mouvement** (Le déplacement s'effectue avec le clique gauche de la souris)
* **L'interaction avec les objets** (Clique droit de la souris)
* **La rotation de la caméra** (Les flèches du clavier ou les touches **WASD**)
* **La touche I** (Ouvre et ferme l'inventaire)
* **La touche U** (Déséquipe tout les équipement sur le joueur et le mets dans l'inventaire)
* **La touche Esc** (Ouvre et ferme le menu de pause)
* **La touche T** (Inflige des dommages au joueur, utilisé à des fins démonstratives, **désactiver lors de la version finale**)

## Références et ressources provenant de l'externe
* [Code du script CameraBillboard](https://gist.github.com/ditzel/6ca74cd88765b98dfffebc2aafce667b) permettant à des éléments UI de faire face à la caméra
* [Code du script Object2Terrain](https://wiki.unity3d.com/index.php?title=Object2Terrain) permet la conversion de modèle vers objet "terrain" dans Unity
* [Tutoriel pour déformation de l'eau](https://youtu.be/3MoHJtBnn2U) script WaterPlaneGen et Noise
* [Tutoriel pour modélisation low poly](https://youtu.be/69J8G1QJGqI) pour modéliser l'ile
* [Tutoriel sur exportation de Blender vers Unity](https://youtu.be/71rRJBqu2KE) pour modéliser et importer les canettes de Blender à Unity
* [Tutoriel sur modélisation du personnage](https://www.youtube.com/user/Cercopithecan) ainsi que feuille de références pour modélisation du personnage