INCLUDE globals.ink
#speaker: 

-> start

===start===
~changeBackground("BookCut")
This story follows the story of Sam, make sure to pay attention to choices and have some fun! #speaker: Narrator 
I really hope I'm able to get some expereinces to fill the scrapbook with, Maybe todays the day! #speaker: Sam #icon:
Maybe I should take a picture, 
~changeBackground("FrogBg")
My perfect examples, so happy my sister got me these. 
~changeBackground("Time")
<b> TUTORIAL TIME!!! <b> When taking a picture <b>click the polaroid if you are using mouse and keyboard and if you are using controller use A+B!<b> #speaker: Narrator
After you've taken a picture <b>drag and drop with your mouse or if your playing with a controller press A+B again.<b> 
To see your progress <b>open up the inventory by clicking on it, or if you are on controller press Y.<b>
That's it back to the game have fun and take your time!
~changeBackground("FrogBg")
~takePics("Froggies")
I wonder how they feel being in the limelight? #speaker: Sam 
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

===HangoutStart===
So um.. #speaker: Sam #icon: Sam_realization
Where would we hang out?
Oh, I'm not sure my dorm is kinda messy but it's still okish...  #speaker: Tola #icon: Tola_awkard
Well we can go to my dorm? it's decently cleaned! #speaker: Sam #icon: Sam_neutral
Hey Tola wanna hang out? #speaker: 
Ah alright sounds good!  #speaker: Tola #icon: Tola_neutral
~show_characters = false 
~changeBackground("Time")
Sam and Tola walk to Sam's dorm #speaker: Narrator 
~show_characters = true
~changeBackground("NightDorm")
Wow this looks pretty cool! I like the vibe you got going on Sam! Very Vintage! #speaker: Tola #icon: Tola_happy
Thanks! My brother really likes this sort of stuff and he ended up giving me some of his stuff. #speaker: Sam #icon: Sam_happy
[Sam puts an Album on to listen while working] #speaker: Narrator 
//Album choices would go here//
You cool with this sort of Music? #speaker: Sam #icon: Sam_realization
Oh, Yeah! Usaully I listen to Break-core but I like listening to Jazz too! #speaker: Tola  #icon: Tola_happy
Alright, let's get to doing this homework! #speaker: Sam #icon: Sam_happy
Sam and Tola do some homework together! #speaker: Narrator
Hey so, Do you know how were supposed to write out this scene, I can't remember what notes were supposed to use?  #speaker: Tola #icon: Tola_awkward
~changeBackground("HW")
~show_characters = false
Oh, Ummmm.  #speaker: Sam #icon: Sam_realization
+I'm pretty sure in these notes  #speaker: Sam #icon: Sam_realization
->HWpos
+I'm not totally sure  #speaker: Sam #icon: Sam_awkward
->HWnet
+Just figure it out  #speaker: Sam #icon: Sam_frustrated
-> HWneg

===HWpos===
~relationship_score += 1
Ohhh Got it, Dang I would've probably been stuck on that for a while thanks!  #speaker: Tola #icon: Tola_happy
No Problem! My sister has me go over these a lot, She's kinda a big film nerd #speaker: Sam #icon: Sam_Happy
Oh that's cool, I used to watch some film theory and film practice videos but it's definitely harder now that I'm doing Hw for it.   #speaker: Tola #icon: Tola_happy
Haha Yeah! I'd defintily say it's harder to remember! #speaker: Sam #icon: Sam_happy
~changeBackground("NightDorm")
~show_characters = true
[Sam looks at Tola's pins] #speaker: Narrator 
+Oh! you have a Zonic pin?  #speaker: Sam #icon: Sam_realization
-> Zonicpin

===Zonicpin===
Oh yeah, I'm like a super geek about that game series? #speaker: Tola #icon: Tola_happy
Have you played it? #icon: Tola_happy
+Yeah i've played it!  #speaker: Sam #icon: Sam_happy
-> PlayedZonic
+Nah but i've seen some edits and gameplay  #speaker: Sam #icon: Sam_neutral
-> Zonicedit

===PlayedZonic===
~relationship_score += 1
Really!! what do you like about it? #speaker: Tola #icon: Tola_happy
Personally I love the gameplay it's pretty fun! Being able to zip and Zop around! Love how we can play as a Porcupine, It's pretty funny to think about but usually a lot of games are like that #speaker: Tola #icon: Tola_happy
[Wow, I never met someone this hyped, Usaully people just say its cool and move on] #speaker: Sam #icon: Sam_realization
~relationship_score += 1
Same! it's Gameplay is super cool love being able to go super fast pretty fun to go throiugh loops! #speaker: Sam #icon: Sam_happy
The designs are really cool too, the shape language is done so well being able to convey how fast the charcter is meant to be by having a bunch of triangles! #speaker: Sam #icon: Sam_happy
The story really captivated me freeing different animals around the different maps!  #speaker: Sam #icon: Sam_happy_2
Right! It's fun being able to talk to someone who also plays the game, most people are usually into the newest games.. #speaker: Tola #icon: Tola_happy
Any other games from the past you like playing  #speaker: Sam #icon: Sam_happy_2
~relationship_score += 1
Ooo theres this one game I played as a kid whenever I could, it's on the tip of my tonuge...  #speaker: Tola #icon: Tola_really
ahh it'll come back to me but it was so appealing it was a simulation sandbox game where'd you go around building and stuff! #speaker: Tola #icon: Tola_neutral
OH I think I know the game, I think it came out like 11 or 12 years ago? Would you like also fight enemies and trya and figure out different methods and you could also invent things right?  #speaker: Sam #icon: Sam_realization
I don't remember inventing... Hmmm ah wait actually yeah! there was haha crazy we played the same video game as kids!  #speaker: Tola #icon: Tola_happy
Yeah it is! #speaker: Sam #icon: Sam_happy
So... #icon: Sam_neutral
+What kind of genre of games do you usally like?  #speaker: Sam #icon: Sam_happy
-> Gamegenre

===Zonicedit===
Ah thats cool too! Anything you like about it. #speaker: Tola #icon: Tola_neutral
Yeah actually i found the Gameplay pretty cool, i wish i could play it but maybe when I can buy it without textbooks burrying me.. #speaker: Sam #icon: Sam_happy
I feel your pain.. #speaker: Tola #icon: Tola_disgust
But I do play Zario kart! #speaker: Sam #icon: Sam_neutral
Oh, Cool... #speaker: Tola #icon: Tola_neutral
+What kind of genre of games do you usally like?  #speaker: Sam #icon: Sam_happy
-> Gamegenre

===HWnet===
~show_characters = false
~changeBackground("Time")
There's an akward silence...maybe Sam has some notes?  #speaker: Narrator
+...  #speaker: Sam #icon: Sam_awkward
->Silence
+Oh um..  #speaker: Sam #icon: Sam_realization
-> Makeup

===HWneg===
~relationship_score -= 1
~show_characters = true
Ah your right sorry... #speaker: Tola #icon: Tola_sad
Maybe you can try helping? #speaker: Narrator
+Oh um..  #speaker: Sam #icon: Sam_realiztion
->Makeup
+...  #speaker: Sam #icon: Sam_awkward
-> Silence 

===Makeup===
~show_characters = true
~changeBackground("NightDorm")
~relationship_score += 1
Hey um, I'm sorry maybe we can look through some notes? #speaker: Sam #icon: Sam_awkward_2
Yeah that sounds good! #speaker: Tola #icon: Tola_happy
(Save) #speaker: Sam #icon: Sam_happy
~changeBackground("Time")
~show_characters = false
Time passes as they do their homework #speaker: Narrator 
~changeBackground("NightDorm")
~show_characters = true
Hey.. #speaker: Sam #icon: Sam_neutral
+Do you wanna take a break  #speaker: Sam #icon: Sam_happy
-> Break

===Break===
~relationship_score += 1
Oh sure! #speaker: Tola #icon: Tola_neutral
You play any games? #speaker: Sam #icon: Sam_happy
Oh I play Zario Kart and some other games like Zonic and 7 Nights! #speaker: Tola #icon: Tola_happy
Oh same, any character you like playing?  #speaker: Sam #icon: Sam_happy
Hmmm personally love playing ghostie #speaker: Tola #icon: Tola_happy
I get that usually I play treema love their little foresty vibes! #speaker: Sam #icon: Sam_happy
Yeah their so cute! #speaker: Tola #icon: Tola_happy_2
~relationship_score += 1 
So wanna play, a few rounds? #speaker: Sam #icon: Sam_neutral
Sure it would be fun! #speaker: Tola #icon: Tola_happy_2
Alright, How are you on like competivte stuff? #speaker: Sam #icon: Sam_neutral
<b>Not something I usaully like, usually spooks me really..<b>  #speaker: Tola #icon: Tola_Awkward
Yeah I get that, let's have a good game. #speaker: Sam #icon: Sam_happy
+Ready to get your butt kicked in Zario Kart  #speaker: Sam #icon: Sam_happy_2
-> TryHard
+Let's have a fun game! #speaker: Sam #icon: Sam_happy
-> GoEasy

===TryHard===
~relationship_score -= 1 
Ha..ha yeah... I've been playing with my boyfriend, so i've got some new stratigies to use. #speaker: Tola #icon: Tola_awkward_2
[oh I might've messed up ] Ogh cool, Which map do you wanna play? #speaker: Sam #icon: Sam_awkward_2
Oh we can play Forest road #speaker: Tola #icon: Tola_neutral
Sure! I've played that map a few times #speaker: Sam #icon: Sam_neutral
Sam has not #speaker: Narrator
+[Game Cutscene] -> GameCut

===GoEasy===
~relationship_score += 1 
Yeah let's! I've been playing with my boyfriend, so I've got some new stratigies to use! #speaker: Tola #icon: Tola_happy Sam_neutral
(Haha, I may lose) Ogh cool, Which map do you wanna play? #speaker: Sam #icon: Sam_awkward_2
Ooo we can play Forest road! #speaker: Tola #icon: Tola_happy
Sure! I've played that map a few times! #speaker: Sam #icon: Sam_happy
Sam has not #speaker: Narrator
+[Game Cutscene] -> GameCut

===Silence===
~show_characters = true
~changeBackground("NightDorm")
~relationship_score -= 4
Hey... It's getting kinda dark, do you still wanna work on the assignment together? #speaker: Sam #icon: Sam_awkward_2
Nah I.. I should probably get going I'll.. I'll see you around.. #speaker: Tola #icon: Tola_sad
Oh ok.. Right see you.. #speaker: Sam #icon: Sam_awkward
Tola leaves #speaker: Narrator 
~show_characters = false
+[Bad Ending] -> Bad 

===Bad===
~changeBackground("BadEndCut")
Yikes, you were kinda akward... Roll credits I guess.. 
+[Credits] -> Credits


===Gamegenre===
Usually I'm a pretty big fan of cozy games, <b> not the biggest on fighting games, people can get pretty mad when they lose not really a fun setting to be in.<b> #speaker: Tola #icon: Tola_awkward_2
Yeah i get that, I've been there it can get pretty akward but hopeflly we can both be good sports. #speaker: Sam #icon: Sam_happy
Yeah, I'd like that! #speaker: Tola #icon: Tola_happy
Sam and Tola shake hands #speaker: Narrator 
+Ready to get your butt kicked in Zario Kart  #speaker: Sam #icon: Sam_happy_2
-> TryHard
+Let's have a fun game!  #speaker: Sam #icon: Sam_happy
-> GoEasy

===GameCut===
~relationship_score += 1 
~show_characters = false
~changeBackground("Game1")
Oh Man, I'm so close.. NO NO NOT THE BOX #speaker: Tola
Yes Yes, I'm gonna win!! #speaker: Sam 
SIKE, Hehe #speaker: Tola
~changeBackground("Game2")
NOOO #speaker: Sam

+Dang it!  #speaker: Sam #icon: Sam_frustrated
-> Dang 
+Good game  #speaker: Sam #icon: Sam_happy_2
-> GoodGame

===Dang===
~relationship_score -= 1
~show_characters = true
~changeBackground("Time")
Tola backs away #speaker: Narrator 
~changeBackground("NightDorm")
Oh right.. i'm sorry, good game? #speaker: Sam #icon: Sam_awkward
Yeah... good game.. #speaker: Sam #icon: Tola_awkward_2
Um.. It's pretty late  #speaker: Sam #icon: Sam_awkward
[3:40am] #speaker: Narrator
We should probably go to sleep #speaker: Sam #icon: Sam_awkward_2
Yeah sounds good, Night #speaker: Tola #icon: Tola_awkward_2
Night #speaker: Sam #icon: Sam_awkward_2
(Ugh, I messed up) #speaker: Sam #icon: Sam_awkward
~show_characters = false
~changeBackground("Time")
They go to sleep #speaker: Narrator 
[Morning arrives]  
~show_characters = true
~changeBackground("MornDorm")
AUghhhh #speaker: Sam #icon: Sam_ughh
Not a morning person? #speaker: Tola #icon: Tola_neutral
Yeah, I am not a morning person. #speaker: Sam #icon: Sam_ughh
Oh, my boyfriend texted asking if i wanna go eat breakfast, think that's my que to leave!  thanks for the hangout it was a blast! #speaker: Tola #icon: Tola_happy
Yeah, No Problem #speaker: Sam #icon: Sam_happy
Oh Wait! wanna take a picture? #icon: Sam_neutral
Oh um Sure! #speaker: Tola #icon: Tola_awkward
Here we go! #speaker: Sam #icon: Sam_happy
+[Good ending] -> GoodEnd

===GoodGame===
~relationship_score += 1
~changeBackground("NightDorm")
~show_characters = true
Good game! that was super fun! #speaker: Sam #icon: Sam_happy
Hahaha, I almost lost if that Box hit me, My boyfriend gets me with it all the time! #speaker: Tola #icon: Tola_happy
[3:00 am] #speaker: Narrator
Man im kinda hungry wanna get something? #speaker: Tola #icon: Tola_happy
I mean..  #speaker: Sam #icon: Sam_realization
+Sure anything you were thinking?  #speaker: Sam #icon: Sam_realization
->Cheesecut
+Nah im pretty burnt out from that gaming  #speaker: Sam #icon: Sam_ughh
-> eepy


===Cheesecut===
~relationship_score += 1
Let's get Mac and Cheese #speaker: Tola #icon: Tola_happy
Mac and Cheese? #speaker: Sam #icon: Sam_realization
Mac and Cheese! #speaker: Tola #icon: Sam_happy_2
Mac and Cheese.. #speaker: Sam #icon: Sam_happy
[Cut to black] #speaker: Narrator  
~show_characters = false
~changeBackground("Time")
They go and grab some mac and cheese from the dorm kitchen #speaker: narrator
Hehehe Mac and Cheese #speaker: Tola 
Shhh I don't think we can be out this late #speaker: Sam
I know, I know, Alright mac and cheese secured. also some hot water! #speaker: Tola
Cool, let's head back. #speaker: Sam 
Tola and Sam head back to Dorm #speaker: narrator 
~changeBackground("NightDorm")
~show_characters = true
Alright lets dig in, I'm starving! #speaker: Tola #icon: Tola_happy_2
Wait before that let's take a picture, this feels memorable! #speaker: Sam #icon: Sam_realization
Hahah you're really into taking pictures in the moment! #speaker: Tola #icon: Tola_happy_2
Yep, now say cheese! #speaker: Sam #icon: Sam_happy
..did you just.. #speaker: Tola #icon: Tola_really
~show_characters = false
~changeBackground("CheesePic") 
~takePics("Cheese")
This looks so goofy, hehehe #speaker: Tola #icon: Tola_happy_2 
Haha, oh dang it's almost 4am, I think we should hit the hay. #speaker: Sam #icon: Sam_ughh
Sounds good #speaker: Tola #icon: Tola_neutral 
~changeBackground("Time")
Sam and Tola sleep the rest of the night away. #speaker: Narrator
+[morning] -> morning

===eepy===
I'm thinking we should go to sleep, It's pretty late. #speaker: Sam #icon: Sam_neutral
Ah, alright, yeah, it's pretty late. Geez, it's 4 a.m. #speaker: Tola #icon: Tola_geez
Yeah we should sleep before we look like zombies in the morning.  #speaker: Sam #icon: Sam_ughh
I feel like I'll look like one regardless, but fair point. #speaker: Tola #icon: Tola_happy
~show_characters = false
~changeBackground("Time")
Sam and Tola go to sleep and rest until morning. #speaker: Narrator
+[morning] -> morning

===morning===
~show_characters = true
~changeBackground("MornDorm")
Yawnnn, Man.. I hate mornings #speaker: Sam #icon: Sam_ughh
Yeah, Why can't we just have stuff start in the afternoon.. #speaker: Tola #icon: Tola_neutral
Because, no one wants to work till like 7pm #speaker: Sam #icon: Sam_ughh
I mean we worked till like 12am #speaker: Tola #icon: Tola_happy
Then we played video games till like.. 3:00am #speaker: Sam #icon: Sam_happy
You gotta admit that was pretty Fun!  #speaker: Tola #icon: Tola_happy
Ha! yeah it was! #speaker: Sam #icon: Sam_happy_2
Wanna go get some breakfast? #speaker: Tola #icon: Tola_happy_2
+Sure, I'm down!  #speaker: Sam #icon: Sam_happy_2
-> Breaky
+Im pretty beat and might catch some shuteye.  #speaker: Sam #icon: Sam_ughh
-> Shuteye

===Breaky===
~relationship_score += 1
Yess! Let's go get some! #speaker: Tola #icon: Tola_happy_2
Sounds good #speaker: Sam #icon: Tola_happy
~show_characters = false 
~changeBackground("Time")
They go to the cafetria and get breakfast #speaker: narrator 
~changeBackground("Cafetria") 
I'm Starving.. What do you usally like to eat for breakfast? #speaker: Sam #icon: Sam_happy 
Oh, I love eating Nuom Kong. there like donuts but I usally pefer those over donuts over here. It looks like this #speaker: Tola #icon: Tola_neutral
//Show Donuts//
Oh cool! I never had one before you definitely have to get me one! 
I'll defintley bring you one, man all this talk about food is getting me hungry but yeah what kind of breakfast do you like? #speaker: Sam #icon: 
Usually I just like have cinnamon pancakes, nothing super special but yeah when im feeling fancy i'll add whipped cream! #speaker: Sam #icon: Sam_happy_2
Oh nice! Man I can't wait to dig in! #speaker: Tola #icon: Tola_happy
Oh wait! #speaker: Sam #icon: Sam_realization
Before that I wanna take a picture! #speaker: Sam #icon: Sam_happy_2
~changeBackground("Breakfast")
Sounds good! I'm just gonna look at this breakfast. #speaker: Tola 
Sounds good! 1..2..3..Click  #speaker: Sam  
~show_characters = false
~takePics("Breakfast")
Done! #speaker: Sam 
Alright let's dig in! #speaker: Tola 
They scarf down the breakfast #speaker: Narrator 
~changeBackground("Cafetria")
Oh, I forgot my stuff in your dorm. Can we go get it? #speaker: Tola #icon: Tola_neutral
Yeah no worries! #speaker: Sam #icon: Sam_happy
~changeBackground("Time")
They walk back to Sam's dorm #speaker: Narrator 
~changeBackground("MornDorm")
~relationship_score += 1 
~show_characters = true
Today was great #speaker: Sam #icon: Sam_happy_2
Either today or last night, whatever it was, it was amazing to hang out. #speaker: Tola #icon: Tola_happy_2
Haha, Yeah it would be fun to do this again. #speaker: Sam #icon: Sam_happy_2
Most definetly we should get some snacks tho! #speaker: Tola #icon: Tola_happy_2
Definetly top priority! Any snacks you like? #speaker: Sam #icon: Sam_happy
Haha, ooo I love sour gummy worms! You?   #speaker: Tola #icon: Tola_happy
I love hot chips! #speaker: Sam #icon: Sam_happy
Same, Well I'll get going #speaker: Tola #icon: Tola_neutral
+Oh Wait, wanna take a picture?  #speaker: Sam #icon: Sam_happy_2
-> Yaypic

===Shuteye===
Understanble, Well I'm gonna get going then! #speaker: Tola #icon: Tola_neutral
+Wait, wanna take a picture?  #speaker: Sam #icon: Sam_realization
-> Yaypic

===Yaypic===
~relationship_score += 1 
~show_characters = false
~changeBackground("TrueEndCut")
Sure! #speaker: Tola #icon:
It was pretty fun hanging out with you man! #speaker: Sam #icon:
Same! Hope we can hang out in the future! #speaker: Tola #icon:
I'm sure we will! #speaker: Sam #icon:
Now say Cheese! #speaker: Sam #icon:
~takePics("Best Day")
Cool, you got the true ending! #speaker: Narrator 
Hope you enjoyed playing!
ROLL CREDITS 
+[Credits] -> Credits

===NeutralEnd===
Thanks for the offer but I'll pass, I got some other projects to work on so i might just push this one off for a lil bit. #speaker: Sam #icon: Sam_neutral
Ah ok, understandable. I'll see you another time then! #speaker: Tola #icon: Tola_neutral
Hey Tola wanna hang out? #speaker: Aisha #icon:
Yeah! See you Sam #speaker: Tola #icon:Tola_neutral
~show_characters = false
~changeBackground("NeutralEndCut")
Any places you wanna go Tola? #speaker: Aisha
I heard of a cat cafe, I wanna see if any of the desserts are good! #speaker: Tola 
Sounds cute any pictures? #speaker: Aisha 
Tola walks off and Sam goes to do homework #speaker: Narrator 
Wow.. You finished like fast.. Roll credits I guess
[Credits] -> Credits

===GoodEnd===
~show_characters = false
~changeBackground("GoodEndCut")
Say Cheese! #speaker: Sam #icon: 
What are we 5?? #speaker: Tola #icon: 
Dude whatever.. 1..2..3! #speaker: Tola #icon: 
[Click]
~takePics("Good End")
[Credits] -> Credits

===Credits===
thanks for playing! 
->DONE
