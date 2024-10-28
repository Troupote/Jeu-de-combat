# Interactions avec le Programme

Toutes les actions sont réalisées via des boutons sur l'interface graphique.

## Choix du Personnage

Lorsque vous lancez le programme, vous serez invité à choisir un personnage parmi les options suivantes :

- **Tank** : Haute santé, faible dommage.
- **Damager** : Faible santé, haut dommage.
- **Healer** : Santé et dommage modérés, peut se soigner.
- **Pierre** : Caractère spécial avec des statistiques aléatoires.

## Actions du Joueur

Pendant le combat, vous pouvez choisir parmi les actions suivantes en cliquant sur les boutons correspondants :

- **Attaquer** : Inflige des dégâts à l'adversaire.
- **Défendre** : Réduit les dégâts subis lors de l'attaque de l'adversaire.
- **Capacité Spéciale** : Utilise une capacité spéciale unique à chaque personnage.

## Actions de l'IA

L'IA choisira aléatoirement parmi les mêmes actions que le joueur :

- Attaquer
- Défendre
- Capacité Spéciale

## Affichage des Statistiques

Les barres de santé et les textes d'information afficheront les points de vie restants et les actions effectuées par le joueur et l'IA.

## Classes de Personnages

### Tank

- **Santé** : 5
- **Dégâts** : 1
- **Capacité spéciale** : Sacrifie un PV pour gagner un point d'attaque pendant ce tour uniquement 

### Damager

- **Santé** : 3
- **Dégâts** : 2
- **Capacité spéciale** : Renvoie les dégats encaissés mais les subis quand même

### Healer

- **Santé** : 4
- **Dégâts** : 1
- **Capacité spéciale** : Peut se soigner de deux PV

### Pierre

- **Santé** : Aléatoire (1 à 7)
- **Dégâts** : Aléatoire (1 à 7)
- Capacité spéciale : Invoque aléatoirement les dieux "CHAISE et THYBAULT" pour modifier les statistiques du joueur :
  - **Effet Positif** : Augmente les points de vie (PV) et les dégâts du joueur de 3 points chacun.
  - **Effet Négatif** : Réduit les PV et les dégâts du joueur de 3 points chacun. Si les PV tombent à zéro, le joueur perd la partie.


## Fin du Jeu

Le jeu se termine lorsque la santé de l'un des combattants atteint zéro. Un message s'affichera pour indiquer le gagnant.
