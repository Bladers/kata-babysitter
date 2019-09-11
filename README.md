# Babysitter Kata

This app calculates the pay of a babysitter based on payable hours worked and the pay rate of the family babysitted.
This project was written in a Test Driven Development format.
First the tests were written and initially failed then code were written to pass each test.
Commits were made as often as possible.

# Installation

Clone or Download the repository.<br />
1. Navigate to directory and open the solution using Visual Studio, Build Solution, Run.
2. Alternatively you can search for "dev" or "developer command prompt" on the Taskbar Search Box.<br/>
3. Open Developer Command Prompt for Visual Studio.<br/>
4. To compile enter "csc -optimize -out:YourLocalDirectory\BabySitterKata\BabySitterKata\BabySitterKata.exe YourLocalDirectory\BabySitterKata\BabySitterKata\*.cs".<br/>
5. Replace "YourLocalDirectory" with the directory that you downloaded the repository to.<br/>
6. Run BabySitterKata.exe<br/>

# Features

As a Babysitter.<br />
In order to get paid for 1 night of work.<br />
1. First you select a family which you want to babysit.<br />
2. Then you enter a valid Start Time. <br />
3. Then you enter a valid End Time.<br />
4. The app calculates your pay based on the pay rate of the selected family within the hours worked.<br />

# Requirements

The babysitter:

* starts no earlier than 5:00PM<br />
* leaves no later than 4:00AM<br />
* only babysits for one family per night<br />
* gets paid for full hours (no fractional hours)<br />

The job:

* Pays different rates for each family (based on bedtimes, kids and pets, etc...)<br />
* Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night<br />
* Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night<br />
* Family C pays $21 per hour before 9pm, then $15 the rest of the night<br />
* The time ranges are the same as the babysitter (5pm through 4am)
