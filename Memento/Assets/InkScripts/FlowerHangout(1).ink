#speaker: 
// variables
VAR choice = false
VAR blank = ""
-> main
===main==
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
Hey Flower! #speaker:StarRail
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
-> DONE