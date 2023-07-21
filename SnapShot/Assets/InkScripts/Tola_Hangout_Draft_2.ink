#speaker: 
// variables
VAR photoMode = false
VAR Notification = false
VAR ActivateScene = ""
VAR cameraCheck = true
VAR inventoryCheck = true
VAR PictureName = ""

+[Start]-> start
===start===
I really hope I'm able to get some expereinces to fill the scrapbook with, Maybe todays the day! #Speaker: Sam #icon:
+[Day start] -> Daystart

===Daystart==
Hey Sam right? #Speaker: Sam #icon: 
That's me Tola right? #Speaker: Tola #icon: 
Yeah! So hey i know we have the same Film class, do you maybe wanna work on the homework together?  #Speaker: Sam #icon: 
+[Oh Sure! i need somebody to help with a few parts too] ->HangoutStart

+[Oh um, Nah I'm good] -> NeutralEnd

===HangoutStart===
So um.. #Speaker: Sam #icon: 
+[where would we hang out?] -> DormQ

===DormQ===
Oh, I'm not sure my dorm is kinda messy but it's still okish...  #Speaker: Tola #icon: 
Well we can go to my dorm? it's decently cleaned #Speaker: Sam #icon: 
Ah alright sounds good!  #Speaker: Tola #icon: 
+[Go to dorm] ->Dormstart

===Dormstart===
Wow this looks pretty cool! I like the vibe you got going on Sam! Very Vintange #Speaker: Tola #icon: 
Thanks! Trying to go for that 90's vintage vibe. #Speaker: Sam #icon: 
[Sam puts an Album on to listen while working]
You cool with this is sort of Music? #Speaker: Sam #icon: 
Yep #Speaker: Tola  #icon: 
+[Alright let's get to doiing this homework!] -> Hwstart

===Hwstart===
//They do some homework together// 
Hey so, Do you know what this problem is?  #Speaker: Tola #icon: 
Oh, Ummmm  #Speaker: Sam #icon: 
+[I'm pretty sure in the notes..] ->HWpos.
+[I'm not totally sure] ->HWnet
+[Just figure it out] -> HWneg

===HWpos===
Ohhh Got it, Dang this hoemwork is hard, Usaully I find it easy #Speaker: Tola #icon: 
Haha yeah, Usually i find it easy too! #Speaker: Sam #icon: 
+[Oh cool you have a Zonic pin] -> Zonicpin

===Zonicpin===
Oh yeah, I'm like a super geek about that game series do you play it? #Speaker: Tola 
#icon:
Have you played it? #Speaker: Tola #icon: 
+[Yeah i've played it!] -> PlayedZonic
+[Nah but i've seen some edits and gameplay] -> Zonicedit

===PlayedZonic===
Really!! what do you like about it? #Speaker: Tola #icon: 
Personally I love the gameplay it's pretty fun! Being able to zip and Zop around! Love how we can play as a Porcupine, It's pretty funny to think about but usually a lot of games are like that #Speaker: Tola #icon: 
[Wow, I never met someone this hyped, Usaully people just say its cool and move on] #Speaker: Sam #icon: 
Same! it's Gameplay is super cool love being able to go super fast pretty fun to go throiugh loops!and yeah the designs are really cool too, the shape language is done so well being able to convey how fast the charcter is meant to be by having a bunch of  , ! The story really captivated me freeing different animals around the different maps!  #Speaker: Sam #icon: 
Right! It's fun being able to talk to someone who also plays the game, most people are usually into the newest games.. #Speaker: Tola #icon: 
+[Any other games from the past you like playing] -> Nostalgia

===Nostalgia===
Ooo theres this one game i played as a kid whenever i could, it's on the tip of my tonuge... ahh it'll come back to me but it was so appealing it was a simulation sandbox  game where'd you go around building and stuff #Speaker: Tola #icon: 
OH i think i know the game, would you like also fight enemies and trya and figure out different methods and you could also invent things right?  #Speaker: Sam #icon: 
I don't remember inventing... Hmmm ah wait actually yeah! there was haha crazy we played the same video game as kids! #Speaker: Tola #icon: 
//that's pretty cool// 
Yeah it is! #Speaker: Sam #icon: 
So... #Speaker: Sam: 
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zonicedit===
Ah thats cool too! Anything you like about it. #Speaker: Tola #icon: 
Yeah actually i found the Gameplay pretty cool, i wish i could play it but maybe when i can buy it without textbooks burrying me.. #Speaker: Sam #icon: 
I feel your pain.. #Speaker: Tola #icon: 
but I do play Zario kart! #Speaker: Sam #icon: 
Oh, Cool #Speaker: Tola #icon: 
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zariokart===
Haaa you wish, I've been playing with my boyfriend, so I've got some new stratigies to use! #Speaker: Tola #Icon: 
(I may lose) Ogh cool, Which map do you wanna play? #Speaker: Sam #Icon: 
Ooo we can play Forest road! #Speaker: Tola #Icon: 
Sure! I've played that map a few times! #Speaker: Sam #Icon: 
+[Game Cutscene] -> GameCut

===HWnet===
There's an akward silence.. 
+[...] ->Silence
+[Oh um] -> Makeup

===HWneg===
Ah your right sorry... #Speaker: Tola #Icon
+[Oh um] ->Makeup
+[...] -> Silence 

===Makeup===
Hey um, I'm sorry maybe we can look through some notes? #speaker: Sam #Icon
Yeah that sounds good! #speaker: Tola #Icon
(Save) #Speaker Sam #Icon
[Time passes]
Hey.. #Speaker: Sam #Icon: 
+[Do you wanna take a break] -> Break

===Break===
Oh sure! #Speaker: Tola #Icon
You play any games? #Speaker: Sam #Icon
Oh i play Zario Kart! #Speaker: Tola #Icon
Oh same, any character you like playing?  #Speaker: Sam #Icon
Hmmm personally love playing ghostie #Speaker: Tola #Icon
I get that usually i play treema love their little foresty vibes! #Speaker: Sam #Icon
Yeah their so cute! #Speaker: Tola #Icon
So wanna play, a few rounds? #Speaker: Sam #Icon
Sure it would be fun! #Speaker: Tola #Icon
Alright, How are you on like competivte stuff #Speaker: Sam #Icon
Not something I usaully like, usually spooks me really #Speaker: Tola #Icon
Yeah i get that, let's have a good game. #Speaker: Sam #Icon
+[Ready to get your butt kicked in Zario Kart] -> Zariokart

===Silence===
Hey... it's getting kinda dark do you still wanna work on the assignment together? #Speaker: Sam #Icon
Nah i should probably get going i'll.. i'll see you around.. #speaker: Tola #Icon
Oh ok.. Right see you #Speaker: Sam #Icon
[Tola leaves]
+[Bad Ending] -> Bad 

===Bad===
I haven't like talked this whole time but like... 
Yikes, you were kinda akward... Roll credits i guess #speaker: Narrator 
+[Credits] -> Credits


===Gamegenre===
Usually I'm a pretty big fan of cozy games, not the biggest on fighting games, people can get [pretty mad when they lose] not really a fun setting to be in. #Speaker: Tola #icon: 
Yeah i get that, I've been there it can get pretty akward but hopeflly we can both be good sports. #Speaker: Sam #icon: 
Yeah id like that! #Speaker: Tola #icon: 
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
Oh right.. i'm sorry, good game? #Speaker: Sam #Icon: 
Yeah... good game.. #Speaker: Sam #Icon: 
Um.. it's pretty late  #Speaker: Sam #Icon: 
[3:40am]
[We should probably go to sleep] -> Honkshoo

===Honkshoo===
Yeah sounds good, Night #speaker: Tola #Icon: 
Night #speaker: Sam #Icon: 
(Ugh, I messed up) #speaker: Sam #Icon: 
[They go to sleep]
+[Day] -> Day

===Day===
" Day arrives'' 
AUghhhh #speaker: Sam #Icon: 
Omg I forgot how much I hate the morning. #speaker: Tola #Icon: 
Yeah, I am not a morning person. #speaker: Tola #Icon: 
Oh, my boyfriend texted asking if i wanna go eat breakfast, think that's my que to leave!  thanks for the hangout it was a blast! #speaker: Tola #Icon: 
Yeah, No Problem #speaker: Sam #Icon: 
Oh Wait! wanna take a picture? #speaker: Sam #Icon: 
Oh um Sure! #speaker: Tola #Icon: 
Here, #speaker: Sam #Icon: 
+[Good ending] -> GoodEnd

===GoodGame===
Good game! that was super fun! #speaker: Sam #Icon: 
Hahaha, You almost won if that shell hit me, but it didn't usually my boyfriend beats me with that so i developed a plan for it but Man im kinda hungry wanna get something? #Speaker: Tola #Icon: 
"3:00 am" 
I mean..  #speaker: Sam #Icon: 
+[Sure anything you were thinking] ->Cheesecut
+[Nah im pretty burnt out from that gaming] -> eepy


===Cheesecut===
Let's get Mac and Cheese #speaker: Tola #Icon: 
Mac and Cheese? #Speaker: Sam #Icon: 
Mac and Cheese! #speaker: Tola #Icon: 
Mac and Cheese.. #Speaker: Sam #Icon: 
[Cut to black]
//They go and grab some mac and cheese from the dorm kitchen//
Hehehe Mac and Cheese #speaker: Tola 
Shhh i dont think we can be out late #Speaker: Sam
I know, i know, Alright mac and cheese secured. also some hot water! #speaker: Tola
Cool, let's head back. #Speaker: Sam 
+[head back to Dorm] ->Secretscene1

===Secretscene1===
Alright lets dig in, I'm starving #speaker: Tola #Icon: 
Wait before that let's take a picture, this feels memoarble! #Speaker: Sam #Icon: 
+[Take picture] -> Cheesepic

===Cheesepic===
Hahah you're really into taking pictures in the moment, #speaker: Tola #Icon: 
Yep, now say cheese #Speaker: Sam #Icon: 
... #speaker: Tola #Icon: 
//Picture cutscene//
this looks so goofy, hehehe #speaker: Tola #Icon: 
Dang it's almost 4am, i think we should hit the hay. #Speaker: Sam #Icon: 
Sounds good #speaker: Tola #Icon: 
+[morning] -> morning

===eepy===
I'm thinking we should go to sleep, It's pretty late. #Speaker: Sam #Icon: 
Ah alright yeah its pretty late.. geez it's 4 am, #Speaker: Tola #Icon: 
Yeah we should sleep before we look like zombies in the morning.  #Speaker: Sam #Icon: 
I feel like i'll look like one regardless, but fair point #Speaker: Tola #Icon: 
//Fade to Black//
+[morning] -> morning

===morning===
Yawnnn, Man.. I hate mornings #Speaker: Sam #Icon: 
Yeah, Why can't we just have stuff start in the afternoon.. #speaker: Tola #Icon: 
Because, no one wants to work till like 7pm #Speaker: Sam #Icon: 
I mean we worked till like 12am #speaker: Tola #Icon: 
Then we played video games till like.. 3:00am #Speaker: Sam #Icon: 
You gotta admit that was pretty Fun!  #speaker: Tola #Icon: 
Ha yeah it was #Speaker: Sam #Icon: 
Wanna go get some breakfast? #Speaker: Tola #Icon: 
+[Sure, Im down] -> Breaky
+[Im pretty beat and might catch some shuteye] -> Shuteye

===Breaky===
Yess! Let's go get some! #speaker: Tola #icon
Sounds good #speaker: Sam #Icon
//They go to the cafetria and get breakfast//
I'm Starving.. #speaker: Tola
I can't wait to dig in! #speaker: Sam
Oh wait. #speaker: Tola
+[Before that i wanna take a picture] -> Breakypic

===Breakypic===
Sounds good! I'm just gonna look at this breakfast. #speaker: Tola #Icon
Sounds good! 1..2..3..Click  #speaker: Sam #Icon
Done! #speaker: Sam #Icon
Alright let's dig in #speaker: Tola #Icon
they scarf down the breakfast
Oh I forgot my stuff in your dorm, can we go get it? #speaker: Tola #Icon
Yeah no worries! #Icon
They walk back to their dorm
+[Today was great] -> Yipeee

===Yipeee===
Yeah today or would it be last night, well whatever it was amazing to hang out.  #speaker: Tola #Icon
haha, Yeah it would be fun to do this again #Speaker: Sam #Icon
Most definetly we should get some snacks tho, #speaker: Tola #Icon
Definetly top priority #Speaker: Sam #Icon
Haha, Well im gonna get going #speaker: Tola #Icon
Oh Wait! #Speaker: Sam #Icon
+[Wait, wanna take a picture?] -> Yaypic

===Shuteye===
Understanble, Well im gonna get going then! $
By- 
+[Wait, wanna take a picture?] -> Yaypic

===Yaypic===
Sure! #speaker: Tola #Icon
It was pretty fun hanging out with you man #Speaker: Sam #Icon
Same! Hope we can hang out in the future! #speaker: Tola #Icon
I'm sure we will! #Speaker: Sam #Icon
Now say Cheese! 1..2..3 *Click* #Speaker: Sam #Icon
+[True ending ] -> True

===True ===
Cool, you got the true ending!
Hope you enjoyed playing!
ROLL CREDITS 
+[Credits] -> Credits

===NeutralEnd===
Thanks for the offer! but i'll pass, I got some other projects to work on so i might just push this one off for a lil bit #Speaker: Sam
Ah ok, understandble i'll see you another time then! #Speaker: Tola
Yep see ya! #Speaker: Sam 
Tola walks off and you go do homework
+[Neutral Ending] -> Neutral

===Neutral===
Wow.. You finished like fast.. Roll credits I guess #Speaker: Narrator 
[Credits] -> Credits

===GoodEnd===
Say Cheese #speaker: Sam #Icon: 
What are we 5??? #speaker: Tola #Icon: 
Dude whatever.. 1..2..3! #speaker: Tola #Icon: 
*Click* 
[Credits] -> Credits

===Credits===
thanks for playing! 
->DONE
