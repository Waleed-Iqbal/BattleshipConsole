NOTE: Excuse the grammatical mistakes.


															BATTLESHIP MINI
															---------------


GUIDE
-----

At the start of the application, you will be asked to place the ships.

First you will have to place 2 destroyers (4 units) and then 1 battleship (1 unit).

When placing any of the ship, you will first have to provide the orientation (vertical/horizontal) of the ship.

Then you will have to provide the location of the ship. Provide the star and end location in the provided coordinate system (A0, A1 ... A9, B0, B1 ... J9).

Make sure to provide appropriate start and end location with exact size.

Example:
For a destroyer, if orientation is vertical, then A0 and A3 are good candidates for the start and end point respectively (A3 can be start point and A0 can be end point), as the distance between A0 and A3 is 4 units which is the size of the destroyer.
Similar thing can be done for battleship.


Once the ships are successfully placed, two boards will be displayed. Board on top is human's and board below is computer's. Computer's board have ships randomly placed.

You will have to hit the computer's ships.

Provide the position of the target just like you provided the positions while placing the ships.

Computer will also randomly try to hit your ships (computer can be made more intelligent)

Eliminate all computer's ships to win the game.



Things that needs/can be improved/added
---------------------------------------

-> Use interfaces properly.
-> Improve the placement of ships from human input. That code needs to be more DRY.
-> Add comments.
-> More user friendly error messages to user for the invalid input.
-> Overlapping ships validation while placing.
-> There is a out of bound exception while placing ships. It occurs very randomly. I wonder how and when that occurs?
-> Code is not as DRY as I wanted.
-> Make computer more intelligent. Use the same logic as the placement of ships to predict the location of human's ships.
-> More testing needs to be done for the invalid input scenarios.
-> A menu screen to start and end game. Also to provide options/settings for adding more ships and increasing/decreasing board size.
-> Gameplay logic of each player should be in their own class rather than in GameState. That needs to be DRY