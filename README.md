# HW4
## Devlog
The model-view-control pattern is utilized in this project to keep the Playyer code decoupled 

The control side of this pattern are the YellowBird player, GameController, and Pipes. This is because the YellowBird player stores the player's movement such as when
space is pressed, the YellowBird can play. GameController is also on the control side of this pattern because it codes for Instantiating pipes, increases the points when passing a pipe,
and also when the game is over depending on if the YellowBird hits a pipe. The Pipes class stores the pipes movement to the left. 
The view side of the Pattern are UI and Audio as they store the point text and audio that reponds to Player input. 

I made the GameController the singleton in my code so that other scripts can locate it with Instance and subscribe to the events that the GameController invokes. 
I chose the GameController specifically because it has a reference to the YellowBird player GameObject. The GameController subscribes to
the player's events that are invoked if the player scores a point, dies when hitting a pipe, or presses space:
if (Player != null) { Player.OnScored += HandlePlayerScored; Player.OnDied += HandlePlayerDied; 
Player.OnFlapped += HandlePlayerFlapped;} with its own method. One method is HandlePlayerFlapped where it codes for increasing of points and calls an event to change the score.
private void HandlePlayerScored() { if (IsGameOver) return; _score++; 
OnScoreChanged?.Invoke(_score);} 
The view aspect of the pattern, UI is then subscribe to this event with its own method that updates the point text. This is all done so that the scripts don't 
need a direct reference to each other and can update their retrospect code by responding to the events that are happening. The other view aspect of the pattern, audio also 
follows the same format. 



## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Flappy Bird Audio](https://www.myinstants.com/en/search/?name=flappy%20bird) - audio source
- [Bird Sprites](https://carysaurus.itch.io/bird-sprites) - yellow bird sprites
- [Pipe Sprites](https://wwolf-w.itch.io/industrial-pipe-platformer-tileset) - pipe sprites