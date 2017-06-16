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

x. Simple cell grid builder
x. Generation runner (move from current to next gen)


Got cell counting far enough along that I would like to start making a grid builder.

One outstanding issue with the cell is verification of linkage.
    when adding a cell should it check with it's neighbors and do some discovery and automatically link?
    also should the cell be able to detect issues with inconsistency?
    or is that the grid manager's duty?

Ran out of time for now, interested in continuing soon.

