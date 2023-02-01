#speaker: 
// variables
VAR photoMode = false
VAR ActivateScene = "DormBackground"
VAR ActivateButton = false
VAR cameraCheck = true
VAR inventoryCheck = true
-> start
===start==
It is 9:00 am on Saturday, the birds are chirping and the sun is so bright...
#speaker: Sam 
Yawn ('What a beautiful day outside!') 
('What am I gonna do today?')
A bird flew onto the edge of the window next to the bed.
('Wasn't expecting that..., but it sure does look cute! I'll take a photo. just hold still...')
->birbscene
===birbscene===
#speaker: #icon:
~ActivateScene = "BirdPhotoScene"
~cameraCheck = false
Wow! What a beautiful bird! I should take out my Camera and take a picture of it to save this moment!
-> main
===main===
"*bzzt* *bzzt*" #speaker: #PlaySound:PhoneNotification
"What's this? It looks like I have a text from Aisha!"#speaker:Sam 
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
~ActivateScene = "KitchenBackground"
I walked to the front door and let Aisha in. #icon: default
I led Aisha to the kitchen so she can sit down. She sat next to me with a smile.
"So Aisha..." #speaker: Sam
"Nice to show up so quickly. Need something? You can tell me. I don't bite!"
"Hahaha! I just wanted to hang out with a friend today, that's all!" #speaker: Aisha #icon:Flower_happy
"Really? Are you sure?" #speaker: Sam #icon:default
"Yeah. really... heh heh..." #speaker: Aisha #icon:Flower_happy
"Aisha," #speaker: Sam #icon:default
"Why are you really here?"
...#speaker: Aisha 
"I needed help to do my homework, it is very difficult this week! It has been stressing me out this whole week too!" #icon:Flower_sad
"I knew it!" #speaker:Sam
('Well I should get my homework out of the way to enjoy the rest of the day. Need to enjoy the weekend!') 
"Alright. How about we get started on our homework then? I'll help you. Also, if you still want to hangout, we can think of a place."

"Wait...for real? That'd be awesome! I'll pick the spot if you don't mind." #speaker: Aisha #icon: Flower_shocked
"Sure, no problem Aisha!" #speaker: Sam #icon:default
"Yes! Thank you so much! Let's get started." #speaker: Aisha #icon: Flower_happy

Aisha and I spent a while doing our homework. #speaker: #icon: 
"Wow. we finally finished our homework!" #speaker: Aisha #icon:default
"Say, why don't we go out to the nearby park? It's sort of lively this time of day, you know?"
"OR, "
"There's a cafe that I would like to take you to. The coffee there is really good!"
-> HangoutChoices
==HangoutChoices==
"Where would you like to go Sam? You pick!" #speaker: Aisha 
~ActivateButton = true
+[Cafe] -> Cafe
+[Park] -> ParkFun
===ParkFun==
"I think I would prefer the park. Lead the way!" #speaker: Sam
"Great! Let's go!" #speaker: Aisha #icon: Flower_happy
-> ParkDate
===ParkDate===
~ActivateScene = "ParkBackground"
#icon:default
Aisha and I walked to the park together, enjoying our time as we came upon people at the park. #speaker:
"Wow, I have never been here, but I can tell it is a good spot!" #speaker: Sam
"I agree, it is so warm here too!" #speaker: Aisha 
"Let's go hangout on the swing set then." #icon: Flower_happy
"Isn't that a little awkward Aisha?" #speaker: Sam #icon:default
"Oh nonsense, we'll be fine! Besides, there aren't too many people here anyway. This place would be good for a dog to play at though!" #speaker: Aisha #icon: Flower_happy
"It would. What kind of dogs do you like Flower? Got a preference?" #speaker: Sam #icon:default
"Oh, well, I sort of like beagles! They are so innocent and cute! How could anyone say no to that face? #speaker: Aisha #icon: Flower_happy
"I'm more of a chihuahua person myself." #speaker: Sam #icon:default
"Small dogs can be a handfull, but I think with enough time, they are all good in the end." #speaker: Aisha
('If there was one here, I'd totally would take a picture...') #speaker: Sam
As if on cue, a woman was walking her dog and Aisha is quick to notice. Aisha quickly went over to the woman and her dog. #icon: Flower_shocked
"Excuse me, miss? Can I pet your dog? He is so precious!" #speaker: Aisha #icon: Flower_happy
"Oh, sure! He loves the attention!" #speaker: Woman #icon:default
Aisha pet the dog, earning a few licks on her hand. She beckoned Sam over.
"Here Sam, come quick! This dog is so amazing!"#speaker:Flower #icon:Flower_happy
('That dog is really cute. I reminds me of the one I saw last week. I love living here!') #speaker: 
"Is it alright if I take a photo of your dog ma'am?" #speaker: Sam #icon:default
"I'd be happy if you would!" #speaker: Woman
"Great! Oh, and you can keep petting him Aisha. This is gonna look great!" #speaker: Sam
"Good idea!" #speaker: Aisha #icon: Flower_happy
-> ParkPhoto

===ParkPhoto===
~cameraCheck = false
~ActivateScene = "ParkPhoto"
Take a photo quickly Sam, I wanna keep playing with him! #icon:
-> ParkDateEnd

===ParkDateEnd===
~ActivateScene = "AfternoonParkBackground"
Aisha and I spent a while at the park, playing with the dog and chilling on the swings afterwards. #icon:default
"I had a good afternoon Aisha! Thanks for inviting me to hangout. It means quite a lot to me. I think I am gonna head home now." #speaker: Sam
"Well it was very worth it! Next time I will have to take you somewhere different! I am sure you would like it! Text me when you get home, okay?" #speaker: Aisha #icon: Flower_happy
Aisha and I waved goodbye to each other as we walked our separate ways home. #speaker: #icon: default
-> WalkingHome

===Cafe===
"I would like to go to the cafe, please!" #speaker: Sam
"Alright, let's go ahead and go!" #speaker:Aisha #icon:Flower_happy
->CoffeeDate

===CoffeeDate===
~ActivateScene = "CafeBackground"
We made our way to the cafe #speaker:
"Here we are, the place I was telling you about! They built it here like a year ago." #speaker: Aisha #icon: default
"This has been one of my favorite shop since! I can't get enough of the aroma and vibe here, ya know?"
"It does look really nice in here." #speaker: Sam
"So how often do you come here, Aisha?"
"Oh you know, only when I need to unwind, or study. It helps me focus." #speaker: Aisha
('Tell me about it. All that load of homework really could have been easy to get through here...') #speaker: Sam
We spent a little while here, drinking coffee and chatting. #speaker: 
"Hey, Sam, do you still have that old camera from the photo club? The one from the eighties?" #speaker: Aisha
"Yeah. I almost never leave my dorm without it, you know?" #speaker: Sam
"You know, I think it would be a good idea to take a photo here. Ya know, for your scrapbook thing?" #speaker: Aisha #icon: Flower_happy
"It would make a great photo for photo club!"
"It would be a good idea, I suppose. I have an idea! #speaker: Sam #icon: default
"Aisha, would you mind if I took a photo of you in this cafe? Just this once?"
"WHAT?! Y-You want to take a photo of me?! #speaker:Aisha #icon: Flower_shocked
"Mhm. It would make a good picture, plus we get to capture all that we did today!" #speaker: Sam
"Oh I see...well, when you put it like that...#speaker:Aisha #icon: Flower_sad
"How could I say no?" #speaker:Aisha #icon: Flower_happy
"Nice! Let me get out my camera!" #icon: default
"And Sam, thanks for hanging out with me!" #speaker:Aisha #icon: Flower_happy
"Thank you for inviting me! Now..." #speaker: Sam
"Say 'Cheese'!"
-> CafePhoto

===CafePhoto===
~cameraCheck = false
~ActivateScene = "CafePhoto"
"Cheese!" #speaker: Aisha #icon: 
->CoffeeDateEnd

===CoffeeDateEnd==
~ActivateScene = "CafeBackground"
Hey Aisha! Take a look at the photo! #speaker: Sam
"Wow that's a great photo! You have to keep that one Sam!" #speaker: Aisha #icon: Flower_happy
"Thanks!" #speaker: Sam
"Well it is getting a bit late. Think we should call it a day?" #speaker: Aisha #icon: default
"Sounds good to me, I'll catch you later, Aisha!" #speaker: Sam
Aisha and I parted ways for the day, waving goodbye to each other after leaving the cafe.
-> WalkingHome

===WalkingHome==
#icon: #speaker: 
~ActivateScene = "NightSidewalkBackground"
('I had a lot of fun with Aisha today. We definitely need to hangout more!')
I walked for a little while back to my dorm, feeling a little tired.
~ActivateScene = "NightTimeKitchenBackground"
Once I got home, I went through the kitchen and straight to my room.
~ActivateScene = "NightDormBackground"
Once I got situated in my room, I layed across my bed before looking up at my corkboard.
('I should totally put that photo of Aisha on the wall. Don't wanna forget about this.')
-> PhotoWall

===PhotoWall===
~ActivateScene = "photoWall"
~inventoryCheck = false
<i>Press I (B on the Xbox Controller) to pull up your Inventory. After your Inventory pops up, click on the picture to post it on the wall. You will be able to continue after you post your picture</i>
<i>Press Space to end Game</i> :)
#EndGame: true
-> END