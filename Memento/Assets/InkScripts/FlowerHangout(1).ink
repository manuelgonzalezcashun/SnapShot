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
I should head to the kitchen.
-> DONE