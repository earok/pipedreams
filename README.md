

		          PIPE DREAMS

		              by

		Dr. Karl Scherer and Eric Hogan
		           Auckland 2020

----------------------------------------------------------------
         >> You can open this manual with Wordpad <<
----------------------------------------------------------------

CONTENT

1.0 : Overview, Puzzles, Problems and Objectives

2.0 : History
3.0 to 6.0 :  Buttons
7.0 to 20.0: Pipe Dreams examples

==================================================================

2.0 HISTORY
2.1 The Invisible Connectors
2.2 One-dimensionality
2.3 Pipe Types

3.0 BUTTONS  (placed at the top left of the screen)

3.1 "Blink" button
3.2 Pipe Type buttons
3.2.1 "New Short" button
3.2.2 "New Long" button
3.2.3 "New Bend45" button
3.2.4 "New Corner 90" button
3.2.5 "New Torus90" button"
3.3 Navigate inside the current pipe dream ("<<", "<5",  "<", ">", "5>", ">>")
3.4 Delete pipe part ("<<", "<",  "del", ">",  ">>")
3.5 Select Pipe Type  ("S", "L", "B". "C", "T") to make it the current one

3.6 Navigating between different Pipe Dreams
   "Dream 01/99" : This is dream number 1 out of  99 possibles.
   Click "Dream name" button to change the name to your liking.

3.7 "Save" button
3.8 "Help" button
3.9 "Copy" button
3.10 "Paste" button

3.11 "Restart This" button and "All" button

3.12 "Raw Data": 
Click it to generate a detailed description of the current pipe dream, in the form of a simple text file (.txt).
The most interesting pipe dreaming created that way will end up 
at the end of this manual (see further down).

3.13  Defining "RECIPE" and "SPECTRUM"
The "recipe" consists of thirty empty spaces to let the system          show the "recipe" of how the pipe dream is made from:
("S" = Short, "L"= Long, "B"= Blend 45, "C"= Corner 90, "T"= Torus90)

4.1 "Thickness" button.

5.0 MOVEMENTS and ROTATIONS  (at lower part of screen)
5.1 "rotate part" buttons
5.2 "MOVE DREAM" buttons
5.3 "TURN DREAM" buttons

6.0 COLOR BUTTONS
6.1 Color button "B"
6.2 Other Color Buttons

==================================================================

7.0 EXAMPLES of pipe dreams and their recipes.
      We start with a few simple exercises, and improve from there.


7.1 Pipe Dream "Torus"   (recipe TTTT, closed loop, store 2)
7.2 Pipe Dream "Square" (recipe CCCC, closed loop, store 3)
7.3 Pipe Dream "Short"   (recipe SS, store 4)
7.4  Pipe Dream "Long"  (recipe LL, store 5)
7.5  Pipe Dream "Flat Octagon"  (recipe BBBB BBBB, closed loop, store 6)
  
(7.6 unused)
7.7 Pipe Dream "Mirror", store 7
7.8 Pipe Dream "Cube", store 8   


8.0 RAW DATA
--------------------
Here all results of pressing the "Raw Data" button are stored.
Size: 99  raw data.
Exercise: try to recreate all given pipe dreams (stored at store 2 to store 99).

8.2 (see 6.1 in manual)   name: "mathematical Torus"  Recipe: TTTT   spectrum: SLBCT= {0,0,0,0,4) , store: 2
8.3 (see 6.2 in manual)    name: "Square Dream"    Recipe: CCCC   spectrum: SLBCT= {0,0,0,4,0) ,  store: 3 
8.4 (see 6.3 in manual)   name "Short Stick"        Recipe: SSSS   Spectrum: SLBCT= {4,0,0,0,0) , store: 4
8.5 (see 6.4 in manual)   name: "LL",  name: "Long Stick",  Recipe = LL, Spectrum: SLBCT= {0,2,0,0,0) ,  store: 5 
8.6 (see 6.5 in manual)   name: "Flat Octagon"    Recipe = BBBB BBBB   Spectrum: SLBCT= {0,0,8,0,0) ,  store: 6  
8.7 (see 6.6 in manual)   name: "Mirror",  Recipe = {BCBBCB},   Spectrum:  SLBCT= {0,0,4,2,0) , store: 7 

8.8 name: "Cube"    Recipe = {CTSTS TSTST  STST}, Spectrum:  SLBCT= {6,0,0,1,7),  store: 8       



================= end of Content list ============================


1.0 : Overview, Puzzles, Problems and Objectives

"Dream Pipes" is a game with various possible applications/objectives:

(1) - Create 3-dimensional pipe systems as pieces of creativity, design, art, fun.
"Pipe Dreams" is a tool that lets you make arty 3-D constructs
(for example, as models for large object for city spaces)

(2) - Demand that your construction uses a only certain "spectrum" (subset) of pipe types, but no others.
                                                                                         
(3) - Demand that for each used pipe type, only a limited supply is available.
                                                            
(4) - Demand that the last pipe part joins perfectly with he first part, and as such is a "closed loop".

(5) - For each pipe type, try to use the minimum number of copies, 
   and then mathematically prove that indeed your usage is the smallest possible.

(6) - In this game, self-intersection is to be avoided at all times.

In Pipe Dreams we will mainly focus on conditions (2) , (4) and (6)
which we will call "spectrum clause", "loop clause" and "no self-touch".

A special sub-case of (4) is the case when our pipe dream loop is a knotted configuration.
We will find that knotted pipe dreams are especially aesthetically pleasing.

So in one sentence our main target might be described as 
"Find the most interesting 3-D knotted pipe constructions, depending on the associated spectra".

==================================================================


2.0 History
-------------
Hello and welcome to Karl Scherer's very special plumbing world,
called "PIPE DREAMS"!
Instead of "Pipe Dream" we will also use the term "object"
or "construction.

Examples of Challenges 
------------------------------
 - Create a loop of piping (which we will call a "Pipe-Loop") such that the starting pipe part
fits to the end pied part like a snake eating its own tail.

PIPE DREAMS is an android game.
It (at least partially) allows you to simulate artful pipe-creations. 
To warm you up several examples have been implemented.

Then game has been invented by Karl Scherer in 2020 and programmed by Eric Hogan.
It is written in the universally acclaimed games programming language "Unity".

The idea is that pieces of water pipes can be connected (welded? glued? stuck together?)
which have been put or glued together under very special conditions,
not necessarily in ways that a plumber would use, but more in a 
3-dimensional and artful way.
In this game we want to state and solve 3-dimensional knots
(puzzles).

The material that the author started up with are high-pressure PVC pipes from the plumber's supply shop.

It started with the author wanting to create some models for artful, large outdoor objects. 
PVC water pipes allow unusual ways to combine real-world pieces of plumbing
for fun and also for creation of new mathematical problems (such as 3-D knots puzzles). 

There are quite a few ways of using PIPE DREAMS:
 - as a fun thing to create arty models of 3-D objects
 - to create aesthetically pleasing 3-D models for art in public spaces
 - as playground to study certain mathematical problems in knot theory
 - to create (wooden models of) your very own personal furniture.

We will talk more about these applications as we go.
The author is sure that you might be able to come up with some more.
The author has never seen that train of thought being applied for games,
furniture etc. There are more interesting applications to be found!  


2.1 The Invisible Connectors
-----------------------------------

The pipe pieces from the hardware shop can be joined with each other
by placing pairs of circular areas together.

For this purpose  smaller pipes (of a smaller diameter)  are attached .
These connecting inner pipe parts (called "connectors") are generally NOT visible in the finished product (pipe dream).

In this PIPE DREAM game we will ignore these inserted, invisible connectors totally.
Not using them makes the simulation (of joining pipe pieces) so much easier and simpler.

Instead we leave it to the program code to join each newly selected pipe part onto the existing pipe sequence.

The resulting pipe sequence will follow a one-dimensional path, which runs in 3-dimensional space. 


2.2 One-dimensionality

Pipe-dreams have a purely one-dimensional structure.
Hence there are no "forks" or "intersections" in this game, just bends and straights.
Overlapping must be avoided at all cost (see below).
In "games language" you could say that you lose when you overlap one pipe part with another.

To be precise, the game has two types of straights ("Long" and "Short"), two types of 90-deg bends  ("Corner90" and "Torus90"), and one 45-deg bend "Bend45".

Pipe Dreams are embedded in the three-dimensional space we all love so much.
In this respect "Pipe Dreams" are quite similar to bending a piece of (quite thick) metal wire,
and turning it into a three-dimensional construction (or piece of modern art), 
which finally turns into an artful object.
Additionally we will in many cases demand that the last pipe piece perfectly is joined to the first pipe piece,
which can turn out to be quite a tricky problem.


2.3 Pipe Types
------------------

Some of these pipe types on offer for sale are
"Long", "Bend 45", "Corner 90").

Two further pipe types which we will use 
are "Short" and "Torus".
"Short" and "Torus"are NOT for sale in hardware shops.

Each pipe type in this game "Pipe Dreams" has exactly two circular contact areas.
These circular areas are the "gluing" surfaces where two pipe parts can join.
Remember, t in this game there are no special connectors that keep the pipe parts together. 

To make a "Short" physically available for hands-on puzzling and manipulation, 
I simply cut a "Long" pipe piece into two "Shorts".
Note that you might have to insert some special "invisible" connectors.)

We see that we end up with five different pipe parts available in this game, 
namely:

-  "Short" 
   Pipe type "Short"  (or "S" for short) is simply a straight piece of pipe of  length 1 and diameter 1.
   It is half as long as the "Long" piece.
 
- "Long" 
   Pipe type "Long" (or  "L" for short) is simply a straight piece of pipe of  length 2 and diameter 1.
   It is twice as long as the "Short" piece.

- "Bend 45"
   Pipe type "Bend 45" (or "Bend" or "B" for short) makes the pipe deviate from the straight line by 45 degrees.

- "Corner 90" (or "Corner" or "C" for short)
   Pipe type "Corner90" is a 90-degrees corner.
   It can be thought of  being a "Torus" piece with two "Short" pieces attached like two arms.
   It is important to understand that in some applications (pipe dreams)
   the three parts of this "Color90" combination cannot be separated, hence can be used 
   only together as one large pipe piece. 

   This limitation will help us to create some quite difficult
   problems (3-D objects, puzzles, brains teasers etc).

- "Torus 90" (or "Torus" or "T" for short) is a 90-degrees corner piece.
   Four copies of a "T" piece can be arranged into a mathematical torus
   (details see below).

It is strongly recommended that you play with the buttons quoted above
to get a feel for this game PIPE DREAMS.
You will find that many controls are self-explanatory.



3.0 CONTROLS  at the top left of the screen
------------------------------------------------------


3.1 "Blink" button:
----------------------

The "blink" button indicates the position of the first pipe part
in the row of joined pipe pieces.

Click it to switch the blink option on/off.
The blinking light highlights the pipe piece currently being in focus.

Statistics: next to the button is displayed:
  - the number of the current pipe part (e.g. 05),
  - the number of the current pipe dream (e.g. 01),
    together as "05/01", meaning "this is the fifth part of first pipe dream number 1."


3.2 Pipe Type buttons
--------------------------

3.2.1 "New Short" button: 

Click it to automatically add a new short straight pipe piece to the existing object.
Statistics: next to the button the amount of copies of the current piece is displayed (such as "01")

3.2.2 "New Long" button: 

Click it to automatically add a new long straight pipe piece to the end of the existing object.
Statistics: next to the button the amount of copies of the current piece is displayed (such as "01")


3.2.3 "New Bend 45" button: 

Click it to automatically add a new pipe piece with a 45-degrees bend to the end of the existing object.
Statistics: next to the button the amount of copies of the current piece is displayed (such as "01")


3.2.4 "New Corner 90" button: 

Click it to automatically add a new right angle pipe piece to the end of the existing object.
Statistics: next to the button the amount of copies of the current piece is displayed (such as "01")


3.2.5 "New Torus 90" button: 

Click it to automatically add a new "90-degrees Torus pipe" piece to the existing object.
Statistics: next to the button the amount of copies of the current piece is displayed (such as "01")
Note that the "interior area" of this torus consists of one single "pinch" point.



3.3 Directional buttons
----------------------------

Directional buttons help you navigate between the various parts of the current pipe.

"<<" directional button:
click it to go to the start of the current pipe.

"<5" directional button
Click go five steps to the left (towards start) of the current type.

"<" directional button:
Click it to go to the previous position in the current pipe.

">" directional button:
Click it to go to the next position in the current pipe.


">5" directional button
Click to go five steps to the right of the current type (towards end)


">>" directional button:

click it to go to the last position in the pipe.




3.4 DELETE buttons
----------------------

"<<", "<", "Del", ">" , ">>" 

where
"<<"  means: delete all the previous parts (the ones to the left),
"<"   means: delete single pipe part to the left,
"Del" means: delete current pipe piece,
">"   means: delete single pipe part to the right,
">>"  means: delete all the parts positioned next in the sequence (to the right),

The delete buttons help you to delete various parts of the pipe.
Please note that you CANNOT delete the last pipe part.



3.5 PIPE TYPES "S", "L" ,"B", "C", "T" buttons
-----------------------------------------------------------

Click one of the option in order to change the current pipe type
into another one,
where "S" = "Small",  "L" = "Long", "B" = "Bend",  "C" = "Corner",  "T" = "Torus"



3.6 Navigation between different Pipe Dreams
--------------------------------------------------------

Your Pipe Dreams (the various pipe objects you have created) are numbered 1 to 99.
Each Pipe Dream consists of at least one part.
NOTE that you cannot delete the last pipe part.

The following directional buttons help you with the navigation.

"<<" directional button:
Click it to go to pipe dream number 1 (out of 99). 

"< 5" directional button:
click it to go  five steps  to the left  (towards the start).
 
"<" directional button:
click it to go to the previous dream in the sequence  (out of 99).

">" directional button:
click it to go to the  next dream in the sequence  (out of 99).


"> 5" directional button:
Click it to go five dreams to  the right  (out of 99).


">>" directional button:
Click it to go to dream number 99  (out of 99).


3.7 "Save" button
---------------------
Click it to store the changes you made to the current object.
The "save" button is blinking as long as your current pipe dream has not been saved.
It is strongly suggested that during your development you save your Pipe Dream regularly!


3.8 "Help" button
---------------------

Click it to see the help text (manual) associated with PIPE DREAMS


3.9 "Copy" button
---------------------
Click it to store the current Pipe Dream to a safe (invisible) storage place.

Only one storage place is available for your Pipoe Dream any time.


3.10 "Paste" button
----------------------

Click it to copy the content of the safe storage to the current object.
Only one storage place is available at any time.


3.11 "Restart This" button
------------------------------

Click it to restart the current object (pipe dream),
numbered between 1 and 99.


"All" button:
---------------

This button is part of the "Restart" options. 
Click it to restart all pipe dreams (numbered 1 to 99).


3.12  RECIPE and SPECTRUM
--------------------------------------

The information how many of each pipe type is used is called the SPECTRUM of your pipe.

The sequence of pipe parts which make up your pipe construction is called the RECIPE of your pipe.

The RECIPE of the current Dream Pipe is displayed at the left border.
Your current pipe part is highlighted.

Example:  
If your pipe is made from a Small followed by a Long followed by a Bend followed by a Long,
then the RECIPE for your pipe is "SLBL" which is indicated at the left border: RECIPE(Pipe) = SLBL,
and the SPECTRUM of your pipe is 
   Spectrum(Pipe) = Spectrum(SLBL) = (S, L, B, C,T)  = (1, 2, 1, 0, 0)

If we want to allow any number of Short in our pipe, we put a star (*)  at its position of the spectrum:
Spectrum (1, 2,1,0,0) is an example of  Spectrum (*, 2, 1 ,0 ,0).

Please note that the SPECTRUM of your creations is NOT displayed anywhere.


==================================================================


4.0 MOVEMENTS and ROTATIONS
----------------------------------------------


4.1 "rotate part" buttons
-----------------------------

Set increment:
Click one of the buttons "1", "5", 10", "15", "45", "90" (degrees)
 go set the rotational increment to this selected number.

Click "L"  to rotate the current pipe part clockwise.
Click "R" to rotate the current pipe part counterclockwise.

Please note that all pipe parts are rotated at the same time.


4.2 "MOVE DREAM" buttons 
-------------------------------------

These "Move DREAM" buttons manipulate your object as one piece.
Hence all parts will be moved at once!

Click "L" to move your object to the left.
Click "R" to move your object to the right.
Click "U" to move your object up.
Click "D" to move your object  down.
Click "F" to move your object  forward away from you in 3-dimensional space).
Click "B" to move your object towards you (in 3-dimensional space).


4.3 "TURN DREAM" buttons
------------------------------------

These "Turn ALL" buttons manipulate your object as one piece.
Hence all parts will be rotated at once!

Click "X" to rotate your object around the X axis.
Click "Y" to rotate your object around the Y axis.
Click "Z" to rotate your object around the Z axis.

Turning is based on the three standard axes of  X, Y and Zs
In Unity terms: X is pitch, Y is yaw, Z is roll.

All moves happen incrementally, and all pipe pieces move at the same time.
The available increment values are: "1", "5", "10", "15", "45", "90" (degrees of rotation).

Incremental setting:
Click the orange button to cycle through the sizes of all available incremental steps.



5.0 "Thickness" slider button
-----------------------------

With this buttons you can control the thickness of the pipes.
You can set it incrementally to values from .1 to 2.0.
It helps to see the overlapping of pipe pieces more clearly. 
The default values is 1, and in general it should stay at that value.



6.0 COLOR buttons
------------------------

6.1 Color button "B"

Click the "B" (background) button to cycle through all available background colors.

6.2 Other Color Buttons

Click one of the color buttons to paint the current pipe parts in this color.
Click the same color button again to paint ALL of your pipe parts with this color.




7.0 EXAMPLES of pipe dreams and their recipes
------------------------------------------------------------

There are many ways to play this game "Pipe Dreams":
here are a few examples:
 - use only some of the five pipe parts S,L,B,C,T for your pipe construction.
 - demand that your pipe construct is CLOSED (see below).
 - avoid any OVERLAPPING of the piping with itself (see below).
 - make sure that your pipe dream is three-dimensional (details on this later).


7.1 Pipe Dream "Mathematical Torus" (recipe TTTT)
----------------------------------------------------------------

Click the "T"  control button in the SLBCT selection.  
A cutout  (one fourth) of a mathematical Torus will appear.
Now click the "New Torus" button three times. 
This will add three more quarters of a torus such that you end up with a full-blown 
mathematical 3-D torus, with a single point (pinch) as the central area.

Congratulations, you have just created your first Pipe Dream!
It is automatically stored in  store 2.

RECIPE
Since we created the torus from four Torus pipe parts,
we could say that our pipe dream is of "recipe TTTT." 
You will find these "recipe indicators" displayed at the lower left border.
Recipes give you a very condensed overview over the structure of your pipe.

Remember that there are only five "building blocks" that make up the toolbox which our pipe-dreams are made from:
Short, Long, Bend, Curve and Torus,
which we will often shorten to S,L,B,C,T.

The game always starts with storage 1.
Since Pipe Dream "Torus" is our first construction,
it is stored in Dream 2 (the second storage in the list of 99 storages of Dream Pipes).

CLOSED SEQUENCE 
To be more precise, we have here a CLOSED loop which is placed in two dimensions.

Later we will meet more closed sequences, especially ones that are living in THREE dimensions.

NON-OVERLAPPING feature.
Looking at our four-piece torus we see that no two parts overlap.



7.2 Pipe Dream "Corners" (recipe "CCCC")

Click the "C"  control button in the SLBCT selection.  
Now click the "New Corner" button three times. 
This will add three more corners such that you end up with a square of piping.

Congratulations, you have just created your second Pipe Dream!
We will call it the "The Square Dream".

RECIPE
Since we created the square piping construct from four "corner" parts,
we could say that our pipe dream is of "recipe CCCC". 
You will find these "recipe indicators" displayed at the lower left border.
Recipes give you a very condensed overview over the structure of your pipe.

Remember that there are only five "building blocks" that make up the toolbox which our pipe-dreams are made from:
Short, Long, Bend, Curve and Torus,
which we will often shorten to S,L,B,C,T.

The game always starts with storage 1.
Since Pipe Dream "Torus" is our first construction,
it is stored in Dream 3 (the third storage in the list of 99 storages of Dream Pipes).

CLOSED SEQUENCE 
We have here a CLOSED loop which is placed in two dimensions.

Later we will meet more closed sequences, especially ones that are living in THREE dimensions.

NON-OVERLAPPING feature.
Looking at our four-piece torus we see that no two parts overlap.

COLORING
Click the blue button to paint the current pipe part blue.
Click the blue button again to paint the whole dream blue.



7.3 Pipe Dream "Short Stick" (recipe SSSS)
----------------------------------------------------

Click the "C"  control button in the SLBCT selection.  

Now click the "New Short" button three times. 
This will add three more pipe parts to your object, each time extending your piping object.

Congratulations, you have just created your third Pipe Dream!
Yes, it's that simple!

RECIPE
Since we created the "Short Stick" from four "Short" pipe parts,
we could say that our stick is built from "recipe SSSS". 
You will find these "recipe indicators" displayed at the lower left border.
Recipes give you a very condensed overview over the structure of your pipe.

Remember that there are only five "building blocks" that make up the toolbox which our pipe-dreams are made from:
Short, Long, Bend, Curve and Torus,
which we will often shorten to S,L,B,C,T.

The game always starts with storage 1.
You can always go back to the beginning (back to the default first pipe part) by clicking the "Reset" button.
Pipe Dream "Short" is our third construction,
it is stored in store 4 (the fourth store in the list of 99 stores).

CLOSED SEQUENCE ?
The sequence is obviously not closed in this case.

Later we will meet more closed sequences, especially ones that are living in THREE dimensions.

NON-OVERLAPPING feature.
Looking at our four-piece torus we see that no two parts overlap.



7.4 Pipe Dream "Long Stick" (recipe LLLL)
-----------------------------------------------------

At the start of the game, click the "Cycle Pipe Type" button repeatedly until it shows the "Long" pipe type.
Now click the "New Long" button three times. 
This will add several long pipe parts to your piping object.

Congratulations, you have just created your third Pipe Dream!
Yes, it's that simple!

RECIPE
Since we created the stick from four "Long" pipe parts,
we could say that our pipe dream is built from "recipe LLLL".
You will find these "recipe indicators" displayed at the lower left border.
Recipes give you a very condensed overview over the structure of your pipe.

Remember that there are only five "building blocks" that make up the toolbox which our pipe-dreams are made from:
Short, Long, Bend, Curve and Torus,
which we will often shorten to S,L,B,C,T.

The game always starts with storage 1.
You can always go back to the beginning (back to the default first pipe part) by clicking the "Reset" button.
Pipe Dream "Short" is our fourth constructed object,
it is stored in Dream 5 (the fifth store in the list of 99 stores).

CLOSED SEQUENCE ?
The sequence is obviously not closed in this case.

Later we will meet more closed sequences, especially ones that are living in THREE dimensions.

NON-OVERLAPPING feature.
Looking at our four-piece construction we see that no two parts overlap.


7.5 Pipe Dream "Flat Octagon" (based on recipe "BBBB BBBB)
----------------------------------------------------------

At the start of the game, click the "Cycle Pipe Type" button repeatedly until it shows the "Bend" pipe type.
Now click the "New Bend" button seven times. 

Congratulations, you have just created your fifth Pipe Dream!

RECIPE
Since we created the piping from eight similar "Bend" pipe parts,
we could say that our pipe dream is of "recipe BBBB BBBB". 
You will find these "recipe indicators" displayed at the lower left border.
Recipes give you a very condensed overview over the structure of your pipe.

Remember that there are only five "building blocks" that make up the toolbox which our pipe-dreams are made from:
Short, Long, Bend, Curve and Torus,
which we will often shorten to S,L,B,C,T.

The game always starts with storage 1.
You can always go back to the beginning (back to the default first pipe part) by clicking the "Reset" button.
Pipe Dream "BBBB BBBB" is our fifth constructed object;
it is stored as Dream 6 (the sixth store in the list of 99 stores).

CLOSED SEQUENCE ?
The sequence is a closed loop in this case.

Later we will meet more closed sequences, especially ones that are living in THREE dimensions,
and even knotted examples among those.

NON-OVERLAPPING feature.
Looking at our four-piece construction we see that no two parts overlap.


==================================================================

8.0 RAW DATA
--------------------

In the following the RAW DATA entries for the Pipe Dreams database are displayed.

These raw data have been  produced by clicking the "Raw Data" button.

------------------------------------------------------------------

8.2 (see 7.1 in manual)   name: "mathematical Torus"  Recipe: TTTT   spectrum: SLBCT= {0,0,0,0,4)  store: 2 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.3 (see 7.2 in manual)    name: "Square Dream"    Recipe: CCCC   spectrum: SLBCT= {0,0,0,4,0)     store: 3 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.4 (see 7.3 in manual)   name "Short Stick", Recipe: SSSS   Spectrum: SLBCT= {4,0,0,0,0), pieces=4, store: 4

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.5 (see 7.4 in manual)   name: "LL",  name: "Long Stick",  Recipe = LL, Spectrum: SLBCT= {0,2,0,0,0) ,), pieces = 2  store: 5 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":1.0,"g":0.5959999561309815,"b":0.5959999561309815,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.6 (see 7.5 in manual)   name: "Flat Octagon"    Recipe = BBBB BBBB   Spectrum: SLBCT= {0,0,8,0,0)), pieces = 12, store: 6

{"BackgroundColor":{"r":0.960784375667572,"g":0.572549045085907,"b":0.572549045085907,"a":1.0},"Pipes":[{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.7 (see 7.6 in manual)   name: "Mirror",  Recipe = {BCBBCB},   Spectrum:  SLBCT= {0,0,4,2,0)), pieces = 12,  store: 7 

{"BackgroundColor":{"r":0.960784375667572,"g":0.572549045085907,"b":0.572549045085907,"a":1.0},"Pipes":[{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.0,"y":0.0,"z":0.0},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.8 name: "Cube"    Recipe = {CTSTS TSTST  STST}, Spectrum:  SLBCT= {6,0,0,1,7), ), pieces = 14, store: 8 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":-90,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":90,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":270,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":0,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":4,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":0.00000571356622458552,"y":0.000005066510766482679,"z":30.000001907348634},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.9 name: "Near-loop"    Recipe = {CCCCC CCCC B}, Spectrum:  SLBCT= {0,0,3,8,0), ), pieces = 12, store: 9 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":55,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-110,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":60,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-20,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":170,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":5,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":180,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":270,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":39.75495147705078,"y":102.54033660888672,"z":182.33029174804688},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.10 name: "Near-loop2"    Recipe = {CCBBC CBBCC BB}, Spectrum:  SLBCT= {0,0,6,6,0), pieces = 12, store: 10 


{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-15,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":180,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":-20,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-185,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":25,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":-160,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":-80,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-190,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":45,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":135,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":-60,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.000004470349267648999,"y":-2.9802322387695315e-8,"z":-0.33333373069763186},"PipeRootRot":{"x":355.4875793457031,"y":229.53575134277345,"z":174.17483520507813},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.11 name: "Near-loop3"    Recipe = {CCCCC CBBCC B}, Spectrum:  SLBCT= {0,0,3,8,0), pieces = 11, store: 11 

{"BackgroundColor":{"r":0.1921568661928177,"g":0.3019607961177826,"b":0.4745098054409027,"a":1.0},"Pipes":[{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":0,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":55,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-110,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":60,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-20,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":170,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":5,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":180,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":3,"Rotation":-5,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}},{"PipeType":2,"Rotation":270,"Color":{"r":0.5,"g":0.5,"b":0.5,"a":1.0}}],"PipeRootPos":{"x":0.0,"y":0.0,"z":0.0},"PipeRootRot":{"x":8.405811309814454,"y":250.73472595214845,"z":184.3224639892578},"PipeRootParentScale":{"x":1.0,"y":1.0,"z":1.0}}

------------------------------------------------------------------

8.12 name: "Near-loop4"    Recipe = {CCBBC CBBCC BB}, Spectrum:  SLBCT= {0,0,3,8,0), pieces = 11, store: 12 


{
    {
    "DreamName": "Near-loop4",
    "Recipe": "CCCCC CBBCC B",
    "Spectrum_SLBCT": "0,0,3,8,0",
    "Pieces": 11,
    "Store": 12,
    "Thickness": "1.0",
    "BackgroundColor": {
        "r": 49,
        "g": 77,
        "b": 121,
        "a": 255
    },
    "Pipes": [
        {
            "PipeType": "C",
            "Rotation": 0,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 15,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 30,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -115,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 60,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -20,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 170,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 15,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 175,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 5,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 265,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        }
    ],
    "PipeRootPos": {
        "x": 0.0,
        "y": 0.0,
        "z": 0.0
    },
    "PipeRootRot": {
        "x": 19.975311279296876,
        "y": 241.2486572265625,
        "z": 137.1530303955078
    },
    "PipeRootParentScale": {
        "x": 1.0,
        "y": 1.0,
        "z": 1.0
    }
}

------------------------------------------------------------------

8.13 name: "Near loop 4"    Recipe = {CCBBC CBBCC BB}, Spectrum:  SLBCT= {0,0,6,6,0), pieces = 12, store: 13 

{
    "DreamName": "Near loop 4",
    "Recipe": "CCBBC CBBCC BB",
    "Spectrum_SLBCT": "0,0,6,6,0",
    "Pieces": 12,
    "Store": 13,
    "Thickness": "1.0",
    "BackgroundColor": {
        "r": 245,
        "g": 245,
        "b": 245,
        "a": 255
    },
    "Pipes": [
        {
            "PipeType": "C",
            "Rotation": 70,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 10,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 175,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": -11,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -190,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 5,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": -160,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": -80,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -190,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 44,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 513,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": -70,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        }
    ],
    "PipeRootPos": {
        "x": -0.3333236873149872,
        "y": -0.000003814697265625,
        "z": -2.3333394527435304
    },
    "PipeRootRot": {
        "x": 358.195068359375,
        "y": 40.788578033447269,
        "z": 267.2487487792969
    },
    "PipeRootParentScale": {
        "x": 1.0,
        "y": 1.0,
        "z": 1.0
    }
}


----------------------------------------------------------------

8.14 name: "Near loop 5", Recipe = {CCBBC CBBCC BB}, Spectrum:  SLBCT= {0,0,3,8,0), pieces = 11, store: 14 


{
    "DreamName": "Near loop 5",
    "Recipe": "CCCCC CBBCC B",
    "Spectrum_SLBCT": "0,0,3,8,0",
    "Pieces": 11,
    "Store": 14,
    "Thickness": "1.0",
    "BackgroundColor": {
        "r": 49,
        "g": 77,
        "b": 121,
        "a": 255
    },
    "Pipes": [
        {
            "PipeType": "C",
            "Rotation": 0,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -25,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 55,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -110,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 60,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -20,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 170,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 5,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": 180,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "C",
            "Rotation": -5,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        },
        {
            "PipeType": "B",
            "Rotation": 270,
            "Color": {
                "r": 128,
                "g": 128,
                "b": 128,
                "a": 255
            }
        }
    ],
    "PipeRootPos": {
        "x": 0.0,
        "y": 0.0,
        "z": 0.0
    },
    "PipeRootRot": {
        "x": 37.753475189208987,
        "y": 279.3921203613281,
        "z": 171.2107391357422
    },
    "PipeRootParentScale": {
        "x": 1.0,
        "y": 1.0,
        "z": 1.0
    }
}

