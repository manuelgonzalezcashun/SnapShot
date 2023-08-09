INCLUDE globals.ink
#speaker: 

-> start

===start===
~changeBackground("BookCut")
I really hope I'm able to get some expereinces to fill the scrapbook with, Maybe todays the day! #speaker: Sam #icon:
+[Let's Go] -> Notebook

===Notebook===
~changeBackground("Classroom")
Hey, Sam right? #speaker: Tola #icon: Tola_neutral
That's me, Tola right? #speaker: Sam #icon: Sam_neutral
Yeah! So hey I know we have the same Film class, do you maybe wanna work on the homework together?  #speaker: Tola #icon: Tola_awkard
+ Oh Sure! I need some help with a few parts too ->HangoutStart
+ Oh um, Nah I'm good -> NeutralEnd

===HangoutStart===
So um.. #speaker: Sam #icon: Sam_realization
Where would we hang out?
Oh, I'm not sure my dorm is kinda messy but it's still okish...  #speaker: Tola #icon: Tola_awkard
Well we can go to my dorm? it's decently cleaned! #speaker: Sam #icon: Sam_neutral
Ah alright sounds good!  #speaker: Tola #icon: Tola_neutral
+[Go to dorm] ->Dormstart

===Dormstart===
~changeBackground("Dorm")
Wow this looks pretty cool! I like the vibe you got going on Sam! Very Vintange! #speaker: Tola #icon: Tola_happy
Thanks! My brother really likes this sort of stuff and he ended up giving me some of his stuff. #speaker: Sam #icon: Sam_happy
[Sam puts an Album on to listen while working]
//Album Choices//
You cool with this is sort of Music? #speaker: Sam #icon: Sam_realization
Oh, Yeah Usaully I listen to Break-core but I like Jazz too! #speaker: Tola  #icon: Tola_happy
+[Alright, let's get to doing this homework!] -> Hwstart

===Hwstart===
The two do some homework together! #speaker: Narrator
Hey so, Do you know how were supposed to write out this scene, I can't remember what notes were supposed to use?  #speaker: Tola #icon: Tola_awkward
//Hw image//
Oh, Ummmm  #speaker: Sam #icon: Sam_realization
+[I'm pretty sure in these notes..] ->HWpos
+[I'm not totally sure] ->HWnet
+[Just figure it out] -> HWneg

===HWpos===
~relationship_score += 1
Ohhh Got it, Dang I would've probably been stuck on that for a while thanks!  #speaker: Tola #icon: Tola_happy
No Problem! My sister has me go over these a lot, She's kinda a big film nerd #speaker: Sam #icon: Sam_Happy
Oh that's cool, I used to watch some film theory and film practice videos but it's definitely harder now that I'm doing Hw for it.   #speaker: Tola #icon: Tola_happy
Haha Yeah! I'd defintily say it's harder to remember! #speaker: Sam #icon: Sam_happy
[Sam looks at Tola's pins #speaker: Narrator 
+[Oh! you have a Zonic pin?] -> Zonicpin

===Zonicpin===
Oh yeah, I'm like a super geek about that game series? #speaker: Tola #icon: Tola_happy
Have you played it? #icon: Tola_happy
+[Yeah i've played it!] -> PlayedZonic
+[Nah but i've seen some edits and gameplay] -> Zonicedit

===PlayedZonic===
~relationship_score += 1
Really!! what do you like about it? #speaker: Tola #icon: Tola_happy
Personally I love the gameplay it's pretty fun! Being able to zip and Zop around! Love how we can play as a Porcupine, It's pretty funny to think about but usually a lot of games are like that #speaker: Tola #icon: Tola_happy
[Wow, I never met someone this hyped, Usaully people just say its cool and move on] #speaker: Sam #icon: Sam_realization
Same! it's Gameplay is super cool love being able to go super fast pretty fun to go throiugh loops!and yeah the designs are really cool too, the shape language is done so well being able to convey how fast the charcter is meant to be by having a bunch of  , ! The story really captivated me freeing different animals around the different maps!  #speaker: Sam #icon: Sam_happy
Right! It's fun being able to talk to someone who also plays the game, most people are usually into the newest games.. #speaker: Tola #icon: Tola_happy
+[Any other games from the past you like playing] -> Nostalgia

===Nostalgia===
~relationship_score += 1
Ooo theres this one game I played as a kid whenever I could, it's on the tip of my tonuge... ahh it'll come back to me but it was so appealing it was a simulation sandbox game where'd you go around building and stuff! #speaker: Tola #icon: Tola_neutral
OH I think I know the game, I think it came out like 11 or 12 years ago? Would you like also fight enemies and trya and figure out different methods and you could also invent things right?  #speaker: Sam #icon: Sam_realization
I don't remember inventing... Hmmm ah wait actually yeah! there was haha crazy we played the same video game as kids!  #speaker: Tola #icon: Tola_happy
Yeah it is! #speaker: Sam #icon: Sam_happy
So... #icon: Sam_neutral
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zonicedit===
Ah thats cool too! Anything you like about it. #speaker: Tola #icon: Tola_neutral
Yeah actually i found the Gameplay pretty cool, i wish i could play it but maybe when I can buy it without textbooks burrying me.. #speaker: Sam #icon: Sam_happy
I feel your pain.. #speaker: Tola #icon: Tola_disgust
But I do play Zario kart! #speaker: Sam #icon: Sam_neutral
Oh, Cool... #speaker: Tola #icon: Tola_neutral
+[What kind of genre of games do you usally like?] -> Gamegenre

===Zariokart===
~relationship_score += 1 
Haaa you wish, I've been playing with my boyfriend, so I've got some new stratigies to use! #speaker: Tola #icon: Tola_happy
(I may lose) Ogh cool, Which map do you wanna play? #speaker: Sam #icon: Sam_awkward_2
Ooo we can play Forest road! #speaker: Tola #icon: Tola_happy
Sure! I've played that map a few times! #speaker: Sam #icon: Sam_happy
He has not #speaker: Narrator
+[Game Cutscene] -> GameCut

===HWnet===
There's an akward silence.. #speaker: Narrator
+[...] ->Silence
+[Oh um] -> Makeup

===HWneg===
~relationship_score -= 1
Ah your right sorry... #speaker: Tola #icon: Tola_sad
+[Oh um] ->Makeup
+[...] -> Silence 

===Makeup===
~relationship_score += 1
Hey um, I'm sorry maybe we can look through some notes? #speaker: Sam #icon: Sam_awkward_2
Yeah that sounds good! #speaker: Tola #icon: Tola_happy
(Save) #speaker: Sam #icon: Sam_happy
[Time passes]
Hey.. #speaker: Sam #icon: Sam_neutral
+[Do you wanna take a break] -> Break

===Break===
~relationship_score += 1
Oh sure! #speaker: Tola #icon: Tola_neutral
You play any games? #speaker: Sam #icon: Sam_happy
Oh I play Zario Kart and some other games like Zonic and 7 Nights! #speaker: Tola #icon: Tola_happy
Oh same, any character you like playing?  #speaker: Sam #icon: Sam_happy
Hmmm personally love playing ghostie #speaker: Tola #icon: Tola_happy
I get that usually I play treema love their little foresty vibes! #speaker: Sam #icon: Sam_happy
Yeah their so cute! #speaker: Tola #icon: Tola_happy_2
So wanna play, a few rounds? #speaker: Sam #icon: Sam_neutral
Sure it would be fun! #speaker: Tola #icon: Tola_happy_2
Alright, How are you on like competivte stuff? #speaker: Sam #icon: Sam_neutral
<b>Not something I usaully like, usually spooks me really..<b>  #speaker: Tola #icon: Tola_Awkward
Yeah i get that, let's have a good game. #speaker: Sam #icon: Sam_happy
+[Ready to get your butt kicked in Zario Kart] -> Zariokart

===Silence===
~relationship_score -= 4
Hey... It's getting kinda dark, do you still wanna work on the assignment together? #speaker: Sam #icon: Sam_awkward_2
Nah I.. I should probably get going I'll.. I'll see you around.. #speaker: Tola #icon: Tola_sad
Oh ok.. Right see you.. #speaker: Sam #icon: Sam_awkward
Tola leaves #Speaker: Narrator 
~show_characters = false
+[Bad Ending] -> Bad 

===Bad===
~changeBackground("BadEndCut")
Yikes, you were kinda akward... Roll credits I guess.. 

+[Credits] -> Credits


===Gamegenre===
Usually I'm a pretty big fan of cozy games, not the biggest on fighting games, people can get pretty mad when they lose not really a fun setting to be in. #speaker: Tola #icon: Tola_awkward_2
Yeah i get that, I've been there it can get pretty akward but hopeflly we can both be good sports. #speaker: Sam #icon: Sam_happy
Yeah, i'd like that! #speaker: Tola #icon: Tola_happy
They shake hands #speaker: Narrator 
+[Ready to get your butt kicked in Zario Kart] -> Zariokart

===GameCut===
~relationship_score += 1 
~show_characters = false
//Insert Cutscene//
Oh Man, I'm so close.. NO NO NOT THE BOX #speaker: Tola
Yes Yes, I'm gonna win!! #speaker: Sam 
SIKE, Hehe #speaker: Tola
NOOO #speaker: Sam
+[Dang it!] -> Dang
+[Good game] -> GoodGame

===Dang===
~relationship_score -= 1
~show_characters = true
Tola backs away
Oh right.. i'm sorry, good game? #speaker: Sam #icon: Sam_awkward
Yeah... good game.. #speaker: Sam #icon: Tola_awkward_2
Um.. it's pretty late  #speaker: Sam #icon: Sam_awkward
[3:40am]
[We should probably go to sleep] -> Honkshoo

===Honkshoo===
Yeah sounds good, Night #speaker: Tola #icon: Tola_awkward_2
Night #speaker: Sam #icon: Sam_awkward_2
(Ugh, I messed up) #speaker: Sam #icon: Sam_awkward
They go to sleep #speaker: Narrator 
+[Day] -> Day

===Day===
" Day arrives'' 
AUghhhh #speaker: Sam #icon: Sam_ughh
Not a morning person? #speaker: Tola #icon: Tola_neutral
Yeah, I am not a morning person. #speaker: Tola #icon: 
Oh, my boyfriend texted asking if i wanna go eat breakfast, think that's my que to leave!  thanks for the hangout it was a blast! #speaker: Tola #icon: Tola_happy
Yeah, No Problem #speaker: Sam #icon: Sam_happy
Oh Wait! wanna take a picture? #icon: Sam_neutral
Oh um Sure! #speaker: Tola #icon: Tola_awkward
Here we go! #speaker: Sam #icon: Sam_happy
+[Good ending] -> GoodEnd

===GoodGame===
~relationship_score += 1
~show_characters = true
Good game! that was super fun! #speaker: Sam #icon: Sam_happy
Hahaha, I almost lost if that Box hit me, My boyfriend gets me with it all the time!   #speaker: Tola #icon: Tola_happy
"3:00 am" 
Man im kinda hungry wanna get something? #icon: Tola_happy
I mean..  #speaker: Sam #icon: Sam_realization
+[Sure anything you were thinking] ->Cheesecut
+[Nah im pretty burnt out from that gaming] -> eepy


===Cheesecut===
~relationship_score += 1
Let's get Mac and Cheese #speaker: Tola #icon: Tola_happy
Mac and Cheese? #speaker: Sam #icon: Sam_realization
Mac and Cheese! #speaker: Tola #icon: Sam_happy_2
Mac and Cheese.. #speaker: Sam #icon: Sam_happy
[Cut to black] //Transition//
~show_characters = false
They go and grab some mac and cheese from the dorm kitchen #speaker: Narrator
Hehehe Mac and Cheese #speaker: Tola 
Shhh i dont think we can be out late #speaker: Sam
I know, i know, Alright mac and cheese secured. also some hot water! #speaker: Tola
Cool, let's head back. #speaker: Sam 
+[head back to Dorm] ->Secretscene1

===Secretscene1===
~show_characters = true
Alright lets dig in, I'm starving #speaker: Tola #icon: 
Wait before that let's take a picture, this feels memoarble! #speaker: Sam #icon: 
+[Take picture] -> Cheesepic

===Cheesepic===
Hahah you're really into taking pictures in the moment! #speaker: Tola #icon: 
Yep, now say cheese #speaker: Sam #icon: 
..did you just.. #speaker: Tola #icon: Tola_really
~show_characters = false
~changeBackground("CheesePic") 
This looks so goofy, hehehe #speaker: Tola #icon: Tola_happy_2 
Haha, oh dang it's almost 4am, I think we should hit the hay. #speaker: Sam #icon: Sam_ughh
Sounds good #speaker: Tola #icon: Tola_neutral
+[morning] -> morning

===eepy===
I'm thinking we should go to sleep, It's pretty late. #speaker: Sam #icon: Sam_neutral
Ah alright yeah its pretty late.. geez it's 4 am, #speaker: Tola #icon: Tola_geez
Yeah we should sleep before we look like zombies in the morning.  #speaker: Sam #icon: Sam_ughh
I feel like i'll look like one regardless, but fair point #speaker: Tola #icon: Tola_happy
//Fade to Black//
+[morning] -> morning

===morning===
~show_characters = true
~changeBackground("Dorm")
Yawnnn, Man.. I hate mornings #speaker: Sam #icon: Sam_ughh
Yeah, Why can't we just have stuff start in the afternoon.. #speaker: Tola #icon: Tola_neutral
Because, no one wants to work till like 7pm #speaker: Sam #icon: Sam_ughh
I mean we worked till like 12am #speaker: Tola #icon: Tola_happy
Then we played video games till like.. 3:00am #speaker: Sam #icon: Sam_happy
You gotta admit that was pretty Fun!  #speaker: Tola #icon: Tola_happy
Ha! yeah it was! #speaker: Sam #icon: Sam_happy_2
Wanna go get some breakfast? #speaker: Tola #icon: Tola_happy_2
+[Sure, Im down!] -> Breaky
+[Im pretty beat and might catch some shuteye.] -> Shuteye

===Breaky===
~relationship_score += 1
Yess! Let's go get some! #speaker: Tola #icon: Tola_happy_2
Sounds good #speaker: Sam #icon: Tola_happy
They go to the cafetria and get breakfast #Speaker: Narrator 
//Insert Background here//
I'm Starving.. What do you usally like to eat for breakfast? #speaker: Sam #icon: Sam_happy 
Oh, I love eating Nuom Kong. there like donuts but I usally pefer those over donuts over here. It looks like this #speaker: Tola #icon: Tola_neutral
//Show Donuts//
Oh cool! I never had one before you definitely have to get me one! 
I'll defintley bring you one, man all this talk about food is getting me hungry but yeah what kind of breakfast do you like? #speaker: Sam #icon: 
Usually I just like have cinnamon pancakes, nothing super special but yeah when im feeling fancy i'll add whipped cream! #speaker: Sam #icon: Sam_happy_2
Oh nice! Man I can't wait to dig in! #speaker: Tola #icon: Tola_happy
Oh wait. #speaker: Sam #icon: Sam_realization
+[Before that i wanna take a picture] -> Breakypic

===Breakypic===
//Insert Background here//
Sounds good! I'm just gonna look at this breakfast. #speaker: Tola 
Sounds good! 1..2..3..Click  #speaker: Sam 
~show_characters = false
//camera scene//
Done! #speaker: Sam 
Alright let's dig in! #speaker: Tola 
They scarf down the breakfast #speaker: Narrator 
Oh I forgot my stuff in your dorm, can we go get it? #speaker: Tola #icon: Tola_neutral
Yeah no worries! #speaker: Sam #icon: Sam_happy
They walk back to their dorm #speaker: Narrator 
+[Today was great] -> Yipeee

===Yipeee===
~relationship_score += 1 
~show_characters = true
Yeah today or would it be last night, well whatever it was amazing to hang out.  #speaker: Tola #icon: Tola_happy_2
haha, Yeah it would be fun to do this again #speaker: Sam #icon: Sam_happy_2
Most definetly we should get some snacks tho, #speaker: Tola #icon: Tola_happy_2
Definetly top priority! Any snacks you like? #speaker: Sam #icon: Sam_happy
Haha, ooo I love sour gummy worms! You?   #speaker: Tola #icon: Tola_happy
I love hot chips! #speaker: Sam #icon: Sam_happy
Same, Well I'll get going #speaker: Tola #icon: Tola_neutral
+[Wait, wanna take a picture?] -> Yaypic

===Shuteye===
Understanble, Well I'm gonna get going then! #speaker: Tola #icon: Tola_neutral
+[Wait, wanna take a picture?] -> Yaypic

===Yaypic===
~relationship_score += 1 
~show_characters = false
~changeBackground("TrueEndCut")
Sure! #speaker: Tola #icon:
It was pretty fun hanging out with you man! #speaker: Sam #icon:
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
Thanks for the offer! but I'll pass, I got some other projects to work on so i might just push this one off for a lil bit #speaker: Sam #icon: Sam_neutral
Ah ok, understandble I'll see you another time then! #speaker: Tola #icon: Tola_neutral
Yep see ya! #speaker: Sam #icon: Sam_neutral
~show_characters = false
~changeBackground("NeutralEndCut")
Tola walks off and Sam goes to do homework #speaker: Narrator 
+[Neutral Ending] -> Neutral

===Neutral===
Wow.. You finished like fast.. Roll credits I guess #speaker: Narrator 
[Credits] -> Credits

===GoodEnd===
~show_characters = false
~changeBackground("GoodEndCut")
Say Cheese #speaker: Sam #icon: 
What are we 5?? #speaker: Tola #icon: 
Dude whatever.. 1..2..3! #speaker: Tola #icon: 
[Click]
[Credits] -> Credits

===Credits===
thanks for playing! 
->DONE
