# robot-simulator
This project creates a toy robot simulator that allows the robot to move around a board. The board has dimensions of 5 units x 5 units. The board uses the Cartesian co-ordinate system and the point (0, 0) represents the bottom-left of the board. Positive x moves to the right and positive y moves upwards.

## Available commands
The robot understands the following commands (These commands are case-sensitive):
 * PLACE X,Y,F where X is the x-coordinate, Y is the y-coordinate and F is the direction that the robot is to face where F can be one of NORTH, EAST, SOUTH or WEST (note: there must not be any spaces between the agument and a comma).
 * MOVE which moves the robot one unit in the direction that it is facing.
 * LEFT which turns the robot to the left.
 * RIGHT which turns the robot to the right.
 * REPORT which reports the location and orientation of the robot.
 * EXIT which exits the simulation.
