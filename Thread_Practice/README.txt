Author: Kyle ROlland
Date: 3/16/2021
File: README.txt
Description: Short description of program, implementation decisions, etc.

This project uses threads to estimate the value of pi. It starts off by prompting the user to enter the amount of darts they want to be thrown, and then asks for the number of threads to be ran.
This information is then used to create two thread lists that run the necessary functions. The threads loop through for all of the darts that are thrown, and any that have a hypotenuse of 1 or lower
count as falling within the circle. The number of darts that fall within the circle is then divided by the total number of darts thrown, and then multiplied by 4 to get the estimate of pi.

This was a surprisingly quick project, but we had a lot of instructions to work off of for this one, which is probably why it was so fast to whip up. I had some trouble with the estimate calculation,
but I realized it was because both the darts and dartsInside variables were integers, so when they were divided, it almost always resulted in 4*0, which gave 0 as an estimate, which is nowhere near the
value of pi, last that I had checked. Thankfully, swapping the dartsInside variable to a double fixed the problem, and made the calculation work properly. I noticed that the results are a little 
inaccurate sometimes, but more entering more darts will help solve that issue, for the most part.

EXTRA CREDIT
There is also a stopwatch that measures how long the program runs, from when the threads are created to when the value of pi is calculated, and the result is then displayed to the user. The program
itself is wrapped in a while loop, which allows the user to run the program as many times as they like, until they enter "1", so that they can enter different values of darts and threads, and can
compare the estimate and runtime results.