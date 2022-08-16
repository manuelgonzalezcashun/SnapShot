#speaker: 
// variables
VAR photoMode = false
VAR saveCharacterData = false
VAR saveBackgroundData = ""
VAR ActivateScene = ""
VAR DeactivateScene = ""
VAR ActivateButton = false
VAR cameraCheck = true
VAR inventoryCheck = true
-> main
===main==
~ActivateScene = "DormBackground"
~saveBackgroundData = "DormBackground"
It is 9:00 am on Saturday, the birds are chirping and the sun is so bright...
#speaker: StarRail 
Yawn ('What a beautiful day outside!') 
('What am I gonna do today?')
"*bzzt* *bzzt*" #speaker: #PlaySound:PhoneNotification
"What's this? It looks like I have a text from Flower!"#speaker:StarRail 
"I should check this out! Better see what she wants. Haven't spoken to her since a few days ago."
#notif:PhoneTrigger
"Looks like she's coming over. I better get the place cleaned up!" #endScene:true
->isReady

===isReady===
('Am I ready to see her yet?')
+ [Yes.] -> StoryFinished
+ [No.] -> lazyhours

===lazyhours===
('I should get five more minutes of sleep.')
-> isReady

===StoryFinished===
('Time to head to the kitchen! I should make us some lunch!')
-> KitchenScene

===KitchenScene===
#speaker:
#playAnimation: DormBackground
~ActivateScene = "KitchenBackground"
~saveBackgroundData = "KitchenBackground"
I walked to the front door and let Flower in.
I led Flower to the kitchen so she can sit down. She sat next to me with a smile.
"So Flower..." #speaker:StarRail
~DeactivateScene = "DormBackground"
"Nice to show up so quickly. Need something? You can tell me. I don't bite!"
#entersChat:true
"Hahaha! I just wanted to hang out with a friend today, that's all!" #speaker: Flower
~saveCharacterData = true
"Really? Are you sure?" #speaker: StarRail
"Yeah. really... heh heh..." #speaker: Flower #icon: default
"Flower," #speaker: StarRail
"Why are you really here?"
...#speaker: Flower 
"I needed help to do my homework, it is very difficult this week! It has been stressing me out this whole week too!" #icon: Flower_sad
"I knew it!" #speaker: StarRail
('Well I should get my homework out of the way to enjoy the rest of the day. Need to enjoy the weekend!')
"Alright. How about we get started on our homework then? I'll help you. Also, if you still want to hangout, we can think of a place."

"Wait...for real? That'd be awesome! I'll pick the spot if you don't mind." #speaker: Flower #icon: Flower_shocked
"Sure, no problem Flower!" #speaker: StarRail
"Yes! Thank you so much! Let's get started." #speaker: Flower #icon: Flower_happy

Flower and I spent a while doing our homework. #speaker: #icon: 

"Wow. we finally finished our homework!" #speaker: Flower #icon:default
#speaker: 
~saveCharacterData = false
~DeactivateScene = "CafeBackground"
#entersChat:false
#playAnimation: CafeBackground
~ActivateScene = "EnterPhotoMode"
~saveBackgroundData = "EnterPhotoMode"
You are now in Photo Mode. Don't worry if it's your first time taking a picture, we will walk you through it :)
Press C (Y on the Xbox Controller) to pull up your Camera. Click on the Reticle to take a photo. After you take a photo, double click on it with left mouse button to save to your inventory.
~cameraCheck = false
~ActivateScene = "photoWall"
#playAnimation: EnterPhotoMode
Once you save your picture in the Inventory you'll be able to continue.
~DeactivateScene = "EnterPhotoMode"
~inventoryCheck = false
Press I (B on the Xbox Controller) to pull up your Inventory. After your Inventory pops up, click on the picture to post it on the wall. You will be able to continue after you post your picture
Press Space to end Game :)
#EndGame: true
-> END