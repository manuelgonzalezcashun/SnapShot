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
"Hahaha! I just wanted to hang out with a friend today, that's all!" #speaker: Flower.
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
"Say, why don't we go out to the nearby park. It's sort of lively this time of day, you know?"
"There's a little spot that I like there."
('Ah a nice stroll in the park. I think I could use that.') #speaker: StarRail
-> Park

===Park===
"Ready to head out. StarRail?"
~ActivateButton = true
+ [Yeah, let's go!] -> ParkFun
+ [Let me look over the problems once more...] -> StudyHard

===ParkFun==
"I'm ready whenever you are!"#speaker: StarRail
"Great! Let's go!" #speaker: Flower #icon: Flower_happy
-> ParkDate

==StudyHard==
"Actually, I think we missed a problem, let's go back and adjust it." #speaker: StarRail
"Oh um. sure! I guess we can try it again, now that I think about it. #speaker: Flower #icon: Flower_shocked
->Park
===ParkDate===
#playAnimation: KitchenBackground
~ActivateScene = "ParkBackground"
~saveBackgroundData = "ParkBackground"
Flower and I walked to the park together, enjoying our time as we came upon people at the park. #speaker:
"Wow, I have never been here, but I can tell it is a good spot!" #speaker: StarRail
"I agree, it is so warm here too!" #speaker: Flower #icon: Flower_happy
~DeactivateScene = "KitchenBackground"
"Let's go hangout on the swing set then." 
"Isn't that a little awkward Flower?" #speaker: StarRail
"Oh nonsense, we'll be fine! Besides, there aren't too many people here anyway. This place would be good for a dog to play at though!" #speaker: Flower #icon: Flower_happy
"It would. What kind of dogs do you like Flower? Got a preference?" #speaker: StarRail
"Oh, well, I sort of like beagles! They are so innocent and cute! How could anyone say no to that face? #speaker: Flower #icon: Flower_happy
"I'm more of a chihuahua person myself." #speaker: StarRail
"Small dogs can be a handfull, but I think with enough time, they are all good in the end." #speaker: Flower #icon: default
('If there was one here, I'd totally would take a picture...') #speaker: StarRail
Flower and I spent a while at the park, talking more about dogs and some of the things around the park.
"Say, StarRail...are you hungry by any chance? It's almost one o'clock, so I figure I would ask." #speaker: Flower #icon: confused
"Oh um...I suppose I am?" #speaker: StarRail
"How about we grab a coffee and lunch at a cafe? I have a nice place in mind for this too." #speaker: Flower #icon: Flower_happy
"Sounds good. You sure get around Flower!" #speaker: StarRail
"Haha! I try, StarRail. I try." #speaker: Flower
('I could use a coffee right about now. Stayed up a little late with that new visual novel game last night...') #speaker: StarRail
-> Coffee

===Coffee==
"Well, are you ready to grab a latte and a bite to eat? I'll pay, it's my treat since you are new!" #speaker: Flower #icon: default
~ActivateButton = true
+[Yes] -> Cafe
+[No] -> Wait

===Cafe===
"Yeah, I'm down to try it." #speaker: StarRail
"Alright, let's go ahead and go!" #speaker:Flower #icon:Flower_happy
->CoffeeDate

===Wait===
"Actually, do you mind if we feed some of the pidgeons? I like the way they all gather." #speaker: StarRail
"Really? Well take your time, I like the nature around here as well.I did not know you liked to watch birds." #speaker:Flower #icon:Flower_confused
-> Coffee

===CoffeeDate===
#playAnimation: ParkBackground
~ActivateScene = "CafeBackground"
~saveBackgroundData = "CafeBackground"
We made our way to the cafe #speaker:
"Here we are, the place I was telling you about! The built it here like a year ago." #speaker: Flower #icon: default
~DeactivateScene = "ParkBackground"
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