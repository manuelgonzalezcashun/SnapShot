INCLUDE globals.ink
#speaker: 

-> start

===start===
I really hope I'm able to get some expereinces to fill the scrapbook with, Maybe todays the day! #speaker: Sam #icon:
Hey Sam right? #speaker: Tola #icon: Tola_neutral
That's me Tola right? #speaker: Sam #icon: 
Yeah! So hey i know we have the same Film class, do you maybe wanna work on the homework together?  #speaker: Tola #icon: 
+ Oh Sure! i need somebody to help with a few parts too ->HangoutStart
+ Oh um, Nah I'm good -> NeutralEnd

===HangoutStart===
So um.. #speaker: Sam #icon: 
where would we hang out?
Oh, I'm not sure my dorm is kinda messy but it's still okish...  #speaker: Tola #icon: 
Well we can go to my dorm? it's decently cleaned #speaker: Sam #icon: 
Ah alright sounds good!  #speaker: Tola #icon:

+[Go to dorm] ->Dormstart

===Dormstart===
Wow this looks pretty cool! I like the vibe you got going on Sam! Very Vintange #speaker: Tola #icon: 
Thanks! Trying to go for that 90's vintage vibe. #speaker: Sam #icon: 
[Sam puts an Album on to listen while working]
You cool with this is sort of Music? #speaker: Sam #icon: 
Yep #speaker: Tola  #icon: 
+[Alright let's get to doiing this homework!] -> Hwstart

===Hwstart===
//They do some homework together// 
Hey so, Do you know what this problem is?  #speaker: Tola #icon: 
Oh, Ummmm  #speaker: Sam #icon: 
+[I'm pretty sure in the notes..] ->HWpos
+[I'm not totally sure] ->HWnet
+[Just figure it out] -> HWneg

===HWpos===
Ohhh Got it, Dang this hoemwork is hard, Usaully I find it easy #speaker: Tola #icon: 
Haha yeah, Usually i find it easy too! #speaker: Sam #icon: 
+[Oh cool you have a Zonic pin] -> Zonicpin

===Zonicpin===
Oh yeah, I'm like a super geek about that game series do you play it? #speaker: Tola #icon:
Have you played it? #speaker: Tola #icon: 
+[Yeah i've played it!] -> PlayedZonic
+[Nah but i've seen some edits and gameplay] -> Zonicedit

===PlayedZonic===
Really!! what do you like about it? #speaker: Tola #icon: 
Personally I love the gameplay it's pretty fun! Being able to zip and Zop around! Love how we can play as a Porcupine, It's pretty funny to think about but usually a lot of games are like that #speaker: Tola #icon: 
[Wow, I never met someone this hyped, Usaully people just say its cool and move on] #speaker: Sam #icon: 
Same! it's Gameplay is super cool love being able to go super fast pretty fun to go throiugh loops!and yeah the designs are really cool too, the shape language is done so well being able to convey how fast the charcter is meant to be by having a bunch of  , ! The story really captivated me freeing different animals around the different maps!  #speaker: Sam #icon: 
Right! It's fun being able to talk to someone who also plays the game, most people are usually into the newest games.. #speaker: Tola #icon: 
+[Any other games from the past you like playing] -> Nostalgia

===Nostalgia===
Ooo theres this one game i played as a kid whenever i could, it's on the tip of my tonuge... ahh it'll come back to me but it was so appealing it was a simulation sandbox  game where'd you go around building and stuff #speaker: Tola #icon: 
OH i think i know the game, would you like also fight enemies and trya and figure out different methods and you could also invent things right?  #speaker: Sam #icon: 
I don't remember inventing... Hmmm ah wait actually yeah! there was haha crazy we played the same video game as kids! #speaker: Tola #icon: 
//that's pretty cool// 
Yeah it is! #speaker: Sam #icon: 
So... #speaker: Sam
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zonicedit===
Ah thats cool too! Anything you like about it. #speaker: Tola #icon: 
Yeah actually i found the Gameplay pretty cool, i wish i could play it but maybe when i can buy it without textbooks burrying me.. #speaker: Sam #icon: 
I feel your pain.. #speaker: Tola #icon: 
but I do play Zario kart! #speaker: Sam #icon: 
Oh, Cool #speaker: Tola #icon: 
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zariokart===
Haaa you wish, I've been playing with my boyfriend, so I've got some new stratigies to use! #speaker: Tola #icon: 
(I may lose) Ogh cool, Which map do you wanna play? #speaker: Sam #icon: 
Ooo we can play Forest road! #speaker: Tola #icon: 
Sure! I've played that map a few times! #speaker: Sam #icon: 
+[Game Cutscene] -> GameCut

===HWnet===
There's an akward silence.. 
+[...] ->Silence
+[Oh um] -> Makeup

===HWneg===
Ah your right sorry... #speaker: Tola #icon:
+[Oh um] ->Makeup
+[...] -> Silence 

===Makeup===
Hey um, I'm sorry maybe we can look through some notes? #speaker: Sam #icon:
Yeah that sounds good! #speaker: Tola #icon:
(Save) #speaker Sam #icon:
[Time passes]
Hey.. #speaker: Sam #icon: 
+[Do you wanna take a break] -> Break

===Break===
Oh sure! #speaker: Tola #icon:
You play any games? #speaker: Sam #icon:
Oh i play Zario Kart! #speaker: Tola #icon:
Oh same, any character you like playing?  #speaker: Sam #icon:
Hmmm personally love playing ghostie #speaker: Tola #icon:
I get that usually i play treema love their little foresty vibes! #speaker: Sam #icon:
Yeah their so cute! #speaker: Tola #icon:
So wanna play, a few rounds? #speaker: Sam #icon:
Sure it would be fun! #speaker: Tola #icon:
Alright, How are you on like competivte stuff #speaker: Sam #icon:
Not something I usaully like, usually spooks me really #speaker: Tola #icon:
Yeah i get that, let's have a good game. #speaker: Sam #icon:
+[Ready to get your butt kicked in Zario Kart] -> Zariokart

===Silence===
Hey... it's getting kinda dark do you still wanna work on the assignment together? #speaker: Sam #icon:
Nah i should probably get going i'll.. i'll see you around.. #speaker: Tola #icon:
Oh ok.. Right see you #speaker: Sam #icon:
[Tola leaves]
+[Bad Ending] -> Bad 

===Bad===
I haven't like talked this whole time but like... 
Yikes, you were kinda akward... Roll credits i guess #speaker: Narrator 
+[Credits] -> Credits


===Gamegenre===
Usually I'm a pretty big fan of cozy games, not the biggest on fighting games, people can get [pretty mad when they lose] not really a fun setting to be in. #speaker: Tola #icon: 
Yeah i get that, I've been there it can get pretty akward but hopeflly we can both be good sports. #speaker: Sam #icon: 
Yeah id like that! #speaker: Tola #icon: 
[They shake hands]
+[Ready to get your butt kicked in Zario Kart] -> Zariokart

===GameCut===
Oh Man, I'm so close.. NO NO NOT THE BOX #speaker: Tola
Yes Yes, Im gonna win!! #speaker: Sam 
SIKE, Hehe #speaker: Tola
NOOO #speaker: Sam
+[Dang it!] -> Dang
+[Good game] -> GoodGame

===Dang===
Tola backs away
Oh right.. i'm sorry, good game? #speaker: Sam #icon: 
Yeah... good game.. #speaker: Sam #icon: 
Um.. it's pretty late  #speaker: Sam #icon: 
[3:40am]
[We should probably go to sleep] -> Honkshoo

===Honkshoo===
Yeah sounds good, Night #speaker: Tola #icon: 
Night #speaker: Sam #icon: 
(Ugh, I messed up) #speaker: Sam #icon: 
[They go to sleep]
+[Day] -> Day

===Day===
" Day arrives'' 
AUghhhh #speaker: Sam #icon: 
Omg I forgot how much I hate the morning. #speaker: Tola #icon: 
Yeah, I am not a morning person. #speaker: Tola #icon: 
Oh, my boyfriend texted asking if i wanna go eat breakfast, think that's my que to leave!  thanks for the hangout it was a blast! #speaker: Tola #icon: 
Yeah, No Problem #speaker: Sam #icon: 
Oh Wait! wanna take a picture? #speaker: Sam #icon: 
Oh um Sure! #speaker: Tola #icon: 
Here, #speaker: Sam #icon: 
+[Good ending] -> GoodEnd

===GoodGame===
Good game! that was super fun! #speaker: Sam #icon: 
Hahaha, You almost won if that shell hit me, but it didn't usually my boyfriend beats me with that so i developed a plan for it but Man im kinda hungry wanna get something? #speaker: Tola #icon: 
"3:00 am" 
I mean..  #speaker: Sam #icon: 
+[Sure anything you were thinking] ->Cheesecut
+[Nah im pretty burnt out from that gaming] -> eepy


===Cheesecut===
Let's get Mac and Cheese #speaker: Tola #icon: 
Mac and Cheese? #speaker: Sam #icon: 
Mac and Cheese! #speaker: Tola #icon: 
Mac and Cheese.. #speaker: Sam #icon: 
[Cut to black]
//They go and grab some mac and cheese from the dorm kitchen//
Hehehe Mac and Cheese #speaker: Tola 
Shhh i dont think we can be out late #speaker: Sam
I know, i know, Alright mac and cheese secured. also some hot water! #speaker: Tola
Cool, let's head back. #speaker: Sam 
+[head back to Dorm] ->Secretscene1

===Secretscene1===
Alright lets dig in, I'm starving #speaker: Tola #icon: 
Wait before that let's take a picture, this feels memoarble! #speaker: Sam #icon: 
+[Take picture] -> Cheesepic

===Cheesepic===
Hahah you're really into taking pictures in the moment, #speaker: Tola #icon: 
Yep, now say cheese #speaker: Sam #icon: 
... #speaker: Tola #icon: 
//Picture cutscene//
this looks so goofy, hehehe #speaker: Tola #icon: 
Dang it's almost 4am, i think we should hit the hay. #speaker: Sam #icon: 
Sounds good #speaker: Tola #icon: 
+[morning] -> morning

===eepy===
I'm thinking we should go to sleep, It's pretty late. #speaker: Sam #icon: 
Ah alright yeah its pretty late.. geez it's 4 am, #speaker: Tola #icon: 
Yeah we should sleep before we look like zombies in the morning.  #speaker: Sam #icon: 
I feel like i'll look like one regardless, but fair point #speaker: Tola #icon: 
//Fade to Black//
+[morning] -> morning

===morning===
Yawnnn, Man.. I hate mornings #speaker: Sam #icon: 
Yeah, Why can't we just have stuff start in the afternoon.. #speaker: Tola #icon: 
Because, no one wants to work till like 7pm #speaker: Sam #icon: 
I mean we worked till like 12am #speaker: Tola #icon: 
Then we played video games till like.. 3:00am #speaker: Sam #icon: 
You gotta admit that was pretty Fun!  #speaker: Tola #icon: 
Ha yeah it was #speaker: Sam #icon: 
Wanna go get some breakfast? #speaker: Tola #icon: 
+[Sure, Im down] -> Breaky
+[Im pretty beat and might catch some shuteye] -> Shuteye

===Breaky===
Yess! Let's go get some! #speaker: Tola #icon:
Sounds good #speaker: Sam #icon:
//They go to the cafetria and get breakfast//
I'm Starving.. #speaker: Tola
I can't wait to dig in! #speaker: Sam
Oh wait. #speaker: Tola
+[Before that i wanna take a picture] -> Breakypic

===Breakypic===
Sounds good! I'm just gonna look at this breakfast. #speaker: Tola #icon:
Sounds good! 1..2..3..Click  #speaker: Sam #icon:
Done! #speaker: Sam #icon:
Alright let's dig in #speaker: Tola #icon:
they scarf down the breakfast
Oh I forgot my stuff in your dorm, can we go get it? #speaker: Tola #icon:
Yeah no worries! #icon:
They walk back to their dorm
+[Today was great] -> Yipeee

===Yipeee===
Yeah today or would it be last night, well whatever it was amazing to hang out.  #speaker: Tola #icon:
haha, Yeah it would be fun to do this again #speaker: Sam #icon:
Most definetly we should get some snacks tho, #speaker: Tola #icon:
Definetly top priority #speaker: Sam #icon:
Haha, Well im gonna get going #speaker: Tola #icon:
Oh Wait! #speaker: Sam #icon:
+[Wait, wanna take a picture?] -> Yaypic

===Shuteye===
Understanble, Well im gonna get going then! $
By- 
+[Wait, wanna take a picture?] -> Yaypic

===Yaypic===
Sure! #speaker: Tola #icon:
It was pretty fun hanging out with you man #speaker: Sam #icon:
Same! Hope we can hang out in the future! #speaker: Tola #icon:
I'm sure we will! #speaker: Sam #icon:
Now say Cheese! 1..2..3 *Click* #speaker: Sam #icon:
+[True ending ] -> True

===True ===
Cool, you got the true ending!
Hope you enjoyed playing!
ROLL CREDITS 
+[Credits] -> Credits

===NeutralEnd===
Thanks for the offer! but i'll pass, I got some other projects to work on so i might just push this one off for a lil bit #speaker: Sam
Ah ok, understandble i'll see you another time then! #speaker: Tola
Yep see ya! #speaker: Sam 
Tola walks off and you go do homework
+[Neutral Ending] -> Neutral

===Neutral===
Wow.. You finished like fast.. Roll credits I guess #speaker: Narrator 
[Credits] -> Credits

===GoodEnd===
Say Cheese #speaker: Sam #icon: 
What are we 5??? #speaker: Tola #icon: 
Dude whatever.. 1..2..3! #speaker: Tola #icon: 
*Click* 
[Credits] -> Credits

===Credits===
thanks for playing! 
->DONE
