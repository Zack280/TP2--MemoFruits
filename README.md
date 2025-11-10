# MemoFruits
MemoFruits est un jeu de mémoire simple destiné aux jeunes enfants. Le jeu nous présente une grille 4x4, totalisant 16 cartes. À chaque tours le joueur choisit deux cartes, elles se retournent face ouverte puis, elles sont comparées. Si elles sont identiques, une paire est trouvée! Par contre, si elles sont différentes, les deux cartes se retournent, arborant leur face cachée. Lorsque toutes les paires sont trouvées, le jeu se termine et le joeur peut choisir de rejouer ou de retourner vers le menu.

## Étapes du développement
### La grille de jeu
L'élément le plus important du jeu est certainement la grille de jeu. Il faut donc choisir un moyen efficace de l'implémenter. Heureusement, nous avons accès à l'outil Grid qui permet de de créer la grille de 16 cases. De plus, en créant 16 boutons, Grid nous permet d'assigner ces derniers à chacune des cases respectives de la grille. Nous avons donc une grille ayant des boutons 
à l'intérieur, représentants nos cartes. Il ne reste plus qu'à insérer les images. Pour cette étape de la grille, il faut utiliser C#. Créons d'abord une liste contenant des boutons. Créons ensuite une seconde liste, cette fois contenat les chemins vers les images, sous forme de strings. En utilisant une boucle foreach, il est possible d'assigner chaque image à deux boutons à la fois. Puisque l'on crée de nouvelles instances de boutons à chaque fois que l'on assigne une imgae, il faut donc insérer ces boutons dans notre première liste. Grâce à la fonction Random() il et possible d'insérer les boutons dans la première liste de manière aléatoire.

### L'aspect visuel
J'ai utilisé Canvas (Canvas.com) pour créer l'animation de l'écran principal. Les pictogrammes de fruits sur les cartes sont des images libres de droits, trouvées sur internet.

## Problèmes durant le développement
- J'ai eu de la difficulté à implémenter un algorithme de mélange afin de mélanger les cartes lors d'une nouvelle partie. Heureusement, la fonction Random et Orderby font le travail pour nous. Source:(https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm)
- Implémentation d'une video: Pour l'aspect esthétiques du jeu, je voulais que le menu principal soit une video, afin d'avoir une animation. Après avoir fait de la recherche, j'ai installer le NuGet Package : Uno.UI . Malheureusement, ce package entre en conflit avec Windows.UI, il ne peuvent opérer en même temps. Alors, j'ai converti la video en un Gif et je l'ai implémenté comme image. Mis à part la qualité de la vidéo qui est nettement réduite, l'animation est présente.
