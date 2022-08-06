#speaker: 
// variables
VAR bgName = ""
VAR saveCharacterData = true
VAR saveBackgroundData = false
VAR deactivateScene = true
VAR deactivebgName = ""
-> main
===main==
~bgName = "DormBackground"
#PlaySound: PolaroidSound
It is 9:00 am on Saturday. 
#speaker: StarRail 
("Yawn. What a beautiful day outside.") 
("What am I gonna do today?")
"*bzzt*" "*bzzt*" #speaker:
#notif:true
What's this, it looks like I have a text from Flower.#speaker:StarRail 
I should check this out! 
Looks like she's coming over. #endScene:true
->isReady

===isReady===
Am I ready to see her yet?
+ [YES] -> StoryFinished
+ [nah] -> lazyhours

===lazyhours===
I should get 5 more minutes of sleep
-> isReady

===StoryFinished===
Time to head to the kitchen.
-> KitchenScene

===KitchenScene===
#entersChat:true
~bgName = "KitchenBackground"
~saveCharacterData = true
~saveBackgroundData = true
Hey Flower! #speaker:StarRail
~deactivateScene = true
~deactivebgName = "DormBackground"
~saveCharacterData = false
~saveBackgroundData = false
Nice to show up unnanounced like that.
Hahaha I just wanted to hang out with a friend today, that's all. #speaker: Flower
Really? #speaker: StarRail
Yeah Really... heh heh... #speaker: Flower #icon: default
Flower. #speaker: StarRail
Why are you really here?
...#speaker: Flower 
I needed help to do my homework #icon: Flower_sad
I knew it! #speaker: StarRail
("Well I should get my homework out of the way to enjoy the rest of the day")
Alright. How about we get started on our homework then? I'll help you.

Wait! For Real! #speaker: Flower #icon: Flower_shocked
Yes! Thank you so much! Let's get started.#icon: Flower_happy

Flower and I spent a while doing our homework. #speaker: #icon: 

Wow we finally finished our homework. #speaker: Flower #icon:default
Say, why don't we go out to get some coffee.
There's a little spot that I like. 

("I could use a coffee") #speaker: StarRail
-> Coffee

===Coffee==
Well are you ready to get some coffee StarRail? #speaker:Flower #icon:default
+[Yes] -> Cafe
+[No] -> Wait

===Cafe===
Yeah let's get some coffee! #speaker:StarRail
Alright let's go then! #speaker:Flower #icon:Flower_happy
->DONE

===Wait===
Actually, I need to do something real quick #speaker:StarRail
Really?  #speaker:Flower #icon:Flower_confused
Well go handle what you have to do then.. . 
-> Coffee
===CoffeeDate===
~deactivebgName = "KitchenBackground"
~bgName = "CafeBackground"
~saveCharacterData = true
~saveBackgroundData = true
We're here! #speaker: Flower #icon:default
This coffee shop is one of my favorite shops in town.
It looks really nice. #speaker: StarRail
How often do you come here? 
Only when I need a break. And after all that studying, I need a coffee break.#speaker: Flower
("You can say that again") #speaker: StarRail
We spent a little while here, drinking coffee and chatting. #speaker: 
Hey do you still have that camera from Photo Club? #speaker: Flower
Yeah, why? #speaker: StarRail
You should take a picture here! #speaker: Flower #icon: Flower_happy
It would be a beautiful picture to show the Photo Club.
It would be... #speaker: StarRail #icon: default
Would you let me take a picture of you Flower?
WHAT!? You wanna take a picture of me? #speaker: Flower #icon: Flower_shocked
Yeah. It would be a good picture. #speaker: StarRail
Oh...#speaker: Flower #icon: Flower_sad
I suppose one picture wouldn't hurt... #icon: default
Alright! #speaker: StarRail
Say "Cheese"!
-> END