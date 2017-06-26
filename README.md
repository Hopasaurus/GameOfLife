# GameOfLife
Conway's Game of Life


Discussed this over lunch and came up with an idea to try.

First iteration will be an attempt at non-array version where neighbor counting is done via refs.


Current plan:

Time is constrained so will be running in three Pomodoro's to get effective use of time.

1. Project setup and start a cell class
    - apparently I was too optimistic pomo 2 is still working on the cell class.
2. Cell: Count living neighbors
    - acheived adding and counting of cardinal neighbors (N,E,S,W)
3. Cell: Count inter-cardinal neighbors (NW, SW, NE, SE) and wrap up cell class.

Pomodoros:
4. Rules: Create a rule processor that will decide cell status for next generation.
	- 



Working Now:
x. Rules
	- Take cell information and yeild a new status for the cell.

Up Next:
x. Simple cell grid builder
	Take in dimensions and yeild a grid that can be run.

	potential test cases:
	- 1x1 grid - not super useful but should not crash
	- 10x1 grid (10 columns, 1 row)
	- 10x10 grid
	- 1x10 grid
	- 100x100 grid
	- 1mx1m grid ? (will it crash and blow up or die cleanly.)

x. Generation runner (move from current to next gen)
	- Cause a grid to progress from current gen to next gen
x. Presentation
	- Provide visual on running the simulation.

Got cell counting far enough along that I would like to start making a grid builder.

To Do - Things we might need:
- aging (advance to the next generation)
- grid manager (build and maintain the grid)
- rules
- presentation - draw something to look at.
- Look into "scientist" view of cells where the cell under observation is counted in the living cell count.
	- This appears to make the rules cleaner.
	- Would like to see what the code change looks like when switching from using the cell-centric view to outside observer view.
- Also would be interesting to look into using a 2d array of bools plus three lines to see how that works out.
	- the current strategy seems to be pretty heavy (but allows for interesting non-grid possiblities.


To Think About:

One outstanding issue with the cell is verification of linkage.
    when adding a cell should it check with it's neighbors and do some discovery and automatically link?
    also should the cell be able to detect issues with inconsistency?
    or is that the grid manager's duty?

