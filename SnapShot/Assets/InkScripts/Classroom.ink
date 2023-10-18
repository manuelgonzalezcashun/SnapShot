INCLUDE globals.ink

-> start

===start===
~changeBackground("BookCut")
This story follows the story of Sam, make sure to pay attention to choices and have some fun! #speaker: Narrator 
I really hope I'm able to get some expereinces to fill the scrapbook with, Maybe todays the day! #speaker: Sam #icon:
Maybe I should take a picture, 
~changeBackground("FrogBg")
My perfect examples, so happy my sister got me these. 
~takePics("Froggies")
I wonder how they feel being in the limelight?
Sam looks at their clock #speaker: Narrator
Almost time for club! #speaker: Sam 
~changeBackground("Time") 
Sam walks to class #speaker: Narrator 
~changeBackground("Classroom")
Hey, Sam right? #speaker: Tola #icon: Tola_neutral
That's me! Tola right? #speaker: Sam #icon: Sam_neutral
Yeah! So hey I know we have the same Film class, do you maybe wanna work on the homework together?  #speaker: Tola #icon: Tola_awkard
+ Oh Sure! I need some help with a few parts too. #speaker: Sam #icon: 
->HangoutStart
+ Oh um, Nah I'm good.  #speaker: Sam #icon:
-> NeutralEnd

===NeutralEnd===
Thanks for the offer but I'll pass, I got some other projects to work on so i might just push this one off for a lil bit. #speaker: Sam #icon: Sam_neutral
Ah ok, understandable. I'll see you another time then! #speaker: Tola #icon: Tola_neutral
Yep see ya! #speaker: Sam #icon: Sam_neutral
~show_characters = false
~changeBackground("NeutralEndCut")
Tola walks off and Sam goes to do homework #speaker: Narrator 
Wow.. You finished like fast.. Roll credits I guess
[Credits] -> Credits 

===HangoutStart===
So um.. #speaker: Sam #icon: Sam_realization
Where would we hang out?
Oh, I'm not sure my dorm is kinda messy but it's still okish...  #speaker: Tola #icon: Tola_awkard
Well we can go to my dorm? it's decently cleaned! #speaker: Sam #icon: Sam_neutral
Ah alright sounds good!  #speaker: Tola #icon: Tola_neutral
~changeScene("Bedroom Scene") 
-> END