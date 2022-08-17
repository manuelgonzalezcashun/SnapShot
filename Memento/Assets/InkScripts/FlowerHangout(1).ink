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
"Say, why don't we go out to the nearby park? It's sort of lively this time of day, you know?"
"OR, "
"There's a cafe that I would like to take you to. The coffee there is really good!"
-> HangoutChoices
==HangoutChoices==
"Where would you like to go StarRail? You pick!" #speaker: Flower #icon: Flower_happy
~ActivateButton = true
+[Cafe] -> Cafe
+[Park] -> ParkFun
===ParkFun==
"I think I would prefer the park. Lead the way!" #speaker: StarRail
"Great! Let's go!" #speaker: Flower #icon: Flower_happy
-> ParkDate
===ParkDate===
#playAnimation: KitchenBackground
~ActivateScene = "ParkBackground"
Flower and I walked to the park together, enjoying our time as we came upon people at the park. #speaker:
"Wow, I have never been here, but I can tell it is a good spot!" #speaker: StarRail
"I agree, it is so warm here too!" #speaker: Flower #icon: Flower_happy
~DeactivateScene = "KitchenBackground"
~saveBackgroundData = true
"Let's go hangout on the swing set then." 
"Isn't that a little awkward Flower?" #speaker: StarRail
"Oh nonsense, we'll be fine! Besides, there aren't too many people here anyway. This place would be good for a dog to play at though!" #speaker: Flower #icon: Flower_happy
"It would. What kind of dogs do you like Flower? Got a preference?" #speaker: StarRail
"Oh, well, I sort of like beagles! They are so innocent and cute! How could anyone say no to that face? #speaker: Flower #icon: Flower_happy
"I'm more of a chihuahua person myself." #speaker: StarRail
"Small dogs can be a handfull, but I think with enough time, they are all good in the end." #speaker: Flower #icon: default
('If there was one here, I'd totally would take a picture...') #speaker: StarRail
As if on cue, a woman was walking her dog and Flower is quick to notice. Flower quickly went over to the woman and her dog. #icon: Flower_shocked
"Excuse me, miss? Can I pet your dog? He is so precious!" #speaker: Flower #icon: Flower_happy
"Oh, sure! He loves the attention!" #speaker: Woman
Flower pet the dog, earning a few licks on her hand. She beckoned StarRail over.
"Here StarRail, come quick! This dog is so amazing!"
('That dog is really cute. I reminds me of the one I saw last week. I love living here!')
"Is it alright if I take a photo of your dog ma'am?" #speaker: StarRail
"I'd be happy if you would!" #speaker: Woman
"Great! Oh, and you can keep petting him Flower. This is gonna look great!" #speaker: StarRail
"Good idea!" #speaker: Flower #icon: Flower_happy
Flower and I spent a while at the park, playing with the dog and chilling on the swings afterwards.
"I had a good afternoon Flower! Thanks for iviting me to hangout. It means quite a lot to me. I think I am gonna head home now." #speaker: StarRail
"Well it was very worth it! Next time I will have to take you somewhere different! I am sure you would like it! Text me when you get home, okay?"" #speaker: Flower #icon: Flower_happy
Flower and I waved goodbye to each other as we walked our separate ways home.
-> DONE
===Cafe===
"I would like to go to the cafe, please!" #speaker: StarRail
"Alright, let's go ahead and go!" #speaker:Flower #icon:Flower_happy
->CoffeeDate

===CoffeeDate===
#playAnimation: KitchenBackground
~ActivateScene = "CafeBackground"
We made our way to the cafe #speaker:
"Here we are, the place I was telling you about! The built it here like a year ago." #speaker: Flower #icon: default
~DeactivateScene = "ParkBackground"
~saveBackgroundData = "CafeBackground"
"This has been one of my favorite shop since! I can't get enough of the aroma and vibe here, ya know?"
"It does look really nice in here." #speaker: StarRail
"So how often do you come here, Flower?"
"Oh you know, only when I need to unwind, or study. It helps me focus." #speaker: Flower
('Tell me about it. All that load of homework really could have been easy to get through here...') #speaker: StarRail
We spent a little while here, drinking coffee and chatting. #speaker: 
"Hey, StarRail, do you still have that old camera from the photo club? The one from the eighties?" #speaker: Flower
"Yeah. I almost never leave my dorm without it, you know?" #speaker: StarRail
"You know, I think it would be a good idea to take a photo here. Ya know, for your scrapbook thing?" #speaker: Flower #icon: Flower_happy
"It would make a great photo for photo club!"
"It would be a good idea, I suppose. I have an idea! #speaker: StarRail #icon: default
"Flower, would you mind if I took a photo of you in this cafe? Just this once?"
"WHAT?! Y-You want to take a photo of me?! #speaker:Flower #icon: Flower_shocked
"Mhm. It would make a good picture, plus we get to capture all that we did today!" #speaker: StarRail
"Oh I see...well, when you put it like that...#speaker:Flower #icon: Flower_sad
"How could I say no?" #speaker:Flower #icon: Flower_happy
"Nice! Let me get out my camera!" #icon: default
"And StarRail, thanks for hanging out with me!" #speaker:Flower #icon: Flower_happy
"Thank you for inviting me! Now..." #speaker: StarRail
"Say 'Cheese'!"
#speaker: 
~saveCharacterData = false
~DeactivateScene = "CafeBackground"
#entersChat:false
#playAnimation: CafeBackground
~ActivateScene = "EnterPhotoMode"
~saveBackgroundData = "EnterPhotoMode"
You are now in Photo Mode. Don't worry if it's your first time taking a picture, we will walk you through it :)
~cameraCheck = false
Press C (Y on the Xbox Controller) to pull up your Camera. Click on the Reticle to take a photo. After you take a photo, double click on it with left mouse button to save to your inventory.
~ActivateScene = "photoWall"
#playAnimation: EnterPhotoMode
~DeactivateScene = "EnterPhotoMode"
~inventoryCheck = false
Press I (B on the Xbox Controller) to pull up your Inventory. After your Inventory pops up, click on the picture to post it on the wall. You will be able to continue after you post your picture
Press Space to end Game :)
#EndGame: true
-> END