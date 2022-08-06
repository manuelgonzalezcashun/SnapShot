#speaker: 
// variables
VAR playAnimation = ""
VAR saveCharacterData = false
VAR saveBackgroundData = false
VAR ActivateScene = ""
VAR DeactivateScene = ""
-> main
===main==
~ActivateScene = "DormBackground"
#PlaySound: PolaroidSound
It is 9:00 am on Saturday. 
#speaker: StarRail 
("Yawn. What a beautiful day outside.") 
("What am I gonna do today?")
"*bzzt*" "*bzzt*" #speaker: #PlaySound:PhoneNotification
What's this, it looks like I have a text from Flower.#speaker:StarRail 
I should check this out! 
#notif:true
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
#playAnimation: DormBackground
~ActivateScene = "KitchenBackground"
~saveCharacterData = true
~saveBackgroundData = true
Hey Flower! #speaker:StarRail
~DeactivateScene = "DormBackground"
Nice to show up unnanounced like that.
Hahaha I just wanted to hang out with a fri""d today, that's all. #speaker: Flower
#entersChat:true
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
->CoffeeDate

===Wait===
Actually, I need to do something real quick #speaker:StarRail
Really?  #speaker:Flower #icon:Flower_confused
Well go handle what you have to do then.. . 
-> Coffee

===CoffeeDate===
#playAnimation: KitchenBackground
~ActivateScene = "CafeBackground"
We made our way to cafe. #speaker: 
We're here! #speaker: Flower #icon:default
~DeactivateScene = "KitchenBackground"
~saveCharacterData = true
~saveBackgroundData = true
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
WHAT!? You wanna take a picture of me? #speaker:Flower #icon: Flower_shocked
Yeah. It would be a good picture. #speaker: StarRail
Oh...#speaker:Flower #icon: Flower_sad
I suppose one picture wouldn't hurt... #icon: Flower_sad
Alright! #speaker: StarRail #icon: default
Say "Cheese"!
-> END