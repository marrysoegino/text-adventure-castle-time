using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class castletimeadventure : MonoBehaviour {

    public AudioSource sfxSource;
    //public Camera mainCam;

    public AudioClip winSound;
    public AudioClip roarsound;
    public AudioClip trollsound;
    public AudioClip sadsound;
    public AudioClip ghostsound;

    public Image pictureofcastle;
    public Image keyImage;

    public string currentRoom;
    public string myText;

    private bool hasSword = false;
    private bool hasShield = false;

    private string room_north;
    private string room_south;
    private string room_west;
    private string room_east;

    public string riddle;

    void Start() {
        myText = "You stumble across a castle and think 'Damn. Treasure' ";
        currentRoom = "title";

       
    }

    void Update()
    {
  
       /* deactivate picture of diego if you're not in the title page or win room
        if (currentRoom == "title" || (currentRoom == "dragon" && hasSword))
        {
            pictureofcastle.enabled = true;
        }
        else
        {
          pictureofcastle.enabled = false;

            //if I wanted to change the image with another
            //portraitOfDiego.sprite = mySpriteVariable;
        }

        if (currentRoom == "dragon" || !hasKey)
        {
          keyImage.enabled = false;
        }
        else
        {
            keyImage.enabled = true; 
            
        } */
        
        
   
        room_north = "nil";
        room_south = "nil";
        room_east = "nil";
        room_west = "nil";
      
       

        //resetting the background and text color, so that if i leave a room
        //where I change it, it doesn't stay that color
       // mainCam.backgroundColor = Color.black;
       GetComponent<Text>().color = Color.white;


        if (currentRoom == "title")
        {
            myText = "Castle Crasher \n\nBy Marry Soegino \n\nYou hear about this treasure in the Northshire,and while searching for this treasure you see a castle in the distance.\n\nPress Space to Begin";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "livingroom";
            }
        }
        else if (currentRoom == "livingroom")
        {

            room_north = "stairs";
            room_west = "garden";


            myText = "You stubble across the living room and see that everything is in pristine order.\n";
            myText += "The living room is not that interesting. However, you see a door to the garden to the left and stairs leading upstairs ahead of you.";


        }
        else if (currentRoom == "garden")
        {

            room_east = "livingroom";

            myText = "You discover the garden that is strangely still vibrant green.\n";

            if (!hasSword)
            {
                myText += "There is a glimmer in the bush. \nPress \"i\" to inspect.";

                if (Input.GetKeyDown(KeyCode.I))
                {

                    currentRoom = "bush";


                }
            }

        }
        else if (currentRoom == "bush")
        {
            // mainCam.backgroundColor = Color.green;
            GetComponent<Text>().color = Color.grey;

            myText = "You found a sword and decided to keep it, deciding it can help defend you from anything that presents danger.\n\n\nPress spacebar to return to the garden.";
            if (!hasSword)
            {
                sfxSource.clip = winSound;
                if (!sfxSource.isPlaying)
                {
                    sfxSource.Play();
                }
            }
            hasSword = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "garden";
            }

        }
        else if (currentRoom == "stairs")
        {

            room_south = "livingroom";
            room_east = "door 1";
            room_north = "hallway";
            room_west = "door 2";

            myText = "You stumble across the creepy, screeching stairs.\n";
            myText += "You see a glowing room on the right and the edge of the hallway in front of you.";
        }
        else if (currentRoom == "door 1")
        {

            room_west = "stairs";

            myText = "You open the door of the kitchen to see the whole room glowing from Pinesol.\n";
            myText += "Your nose becomes overwhelmed by the strong cleaner scent and you close the door quickly before you choke to death by the strong chemicals.";
        }
        else if (currentRoom == "door 2")
        {

            room_east = "stairs";
            room_west = "door 4";

            myText = "It is the servent quarters and the cramped room is reminding you how claustophobic you are. ";
            myText += "You get horrible flashbacks on how your sister would lock you up in a small closet. (Shivers)";

        }
        else if (currentRoom == "door 4")
        {
            sfxSource.clip = ghostsound;
            if (!sfxSource.isPlaying)
            {
                sfxSource.Play();
            }

            myText = "The servent looks at you with a shield in his hand. You ask him if you can get the shield, but he will only give it to you if you answer his question:\nI am less than 30 and I am not 29.\nI am the next number in this pattern: 16, 18, 20, ___ .\n\n\n";
            myText += "Press up for 21\nPress down for 22\nPress right for 25\nPress left for 27";
            //if (!hasShield)
            //{
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    riddle = "servant";
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    riddle = "servant";
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    riddle = "servant";
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    riddle = "correct answer";
                }
                if (riddle == "servant")
                {
                    myText = "You will die now! (You've died).\n";
                    myText += "Press Space to Go Back to the Beginning.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        currentRoom = "door 4";

                    }

                }
                else if(riddle == "correct answer")
                {
                    myText = "You Obtain knowledge outside my comprehension. Congrats you smart YAH!!! Here is your reward.\n\nPress Spacebar to Continue";
                    hasShield = true;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        currentRoom = "door 2";

                    }
                }
            //}
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "livingroom";

            }
        }
        else if (currentRoom == "hallway")
        {

            room_east = "red door";
            room_north = "blue door";
            room_west = "green door";
            room_south = "stairs";

            myText = "You hear voices that are coming from all the bedrooms on that floor.\n";
            myText += "There are 3 rooms from the front and sides of you and they all have different colors on them.";
        }
        else if (currentRoom == "blue door")
        {

            room_south = "hallway";

            myText = "Looking inside, you notice that it is a woman's bedroom.\n";
            myText += "You scavage the place, but nothing catches your interest.";
        }
        else if (currentRoom == "green door")
        {

            room_east = "hallway";

            myText = "Looking inside, you notice it's a man's bedroom.\n";
            myText += "You scavage the place and you see a huge red curtain over the left side of the room.\n";
            myText += "Do you uncover the curtain?\n\n Press Space to uncover the curtains.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "shiny room";
            }
        }
        else if (currentRoom == "shiny room")
        {

            if (hasSword && hasShield)
            {
                sfxSource.clip = sadsound;
                if (!sfxSource.isPlaying)
                {
                    sfxSource.Play();
                }
                myText = "You see the troll looking at you with hungry eyes, but you came prepared.\n";
                myText += "You killed the Troll, HURRAH, but then you saw his daughters crowding around his dead body.";
                myText += "You see the orphaned children crying in their father's arms and you run away from the castle feeling horrible about his murder.";
                myText += "\n\nCongrats you become a Monster. The End D=\n\n\nCredits to Stella for helping me on my time of need.\nPress Space to return to the beginning.";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentRoom = "livingroom";
                }
            }
            else
            {
                sfxSource.clip = trollsound;
                if (!sfxSource.isPlaying)
                {
                    sfxSource.Play();
                }

                myText = "There is a starving Troll that looks at you with hungry eyes and you scurry away.\n\n Press space to return to the hallway";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentRoom = "hallway";
                }

            }


        }
        else if (currentRoom == "red door")
        {

            room_east = "strange noise";
            room_west = "stairs";

            myText = "This bedroom looked destroyed compared to the other bedrooms.\n";
            myText += "Suddenly, you hear there was a loud roar coming the right side of the room.";
        }
        else if (currentRoom == "strange noise")
        {

            sfxSource.clip = roarsound; 
            if (!sfxSource.isPlaying)
            {
                sfxSource.Play();
            }

            if (hasSword && hasShield)
            {
                myText = "It's a DRAGON. You had a fierce battle with the dragon and got injured, but the dragon and you decided to be friendly. The dragon decides that you can take a gold amulet. You gain both wealth and a new friend.";
                myText += "\n\nTHE END!! =D\n\n\nCredits to Stella for helping me on my time of need.";
            }
            else
            {

                myText = "It's a DRAGON. You didn't want to take the chances to die and decide that you need a weapon and protection to kill the monster.\n\n Press space to return to the hallway";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentRoom = "hallway";
                }

            }


        }
        else
        {

            myText = "You have fallen into a void because the game designer is a garbage game designer and the developer is bad too and some variable is set wrong, specifically currentRoom.";

        }


        myText += "\n\n\n";
        if (room_north != "nil")
        {

            myText += "Press Up to go to the " + room_north + "\n";

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                currentRoom = room_north;

            }
        }


        if (room_south != "nil")
        {

            myText += "Press Down to go to the " + room_south + "\n";

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {


                currentRoom = room_south;

            }
        }

        if (room_east != "nil")
        {

            myText += "Press Right to go to the " + room_east + "\n";

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                currentRoom = room_east;

            }
        }

        if (room_west != "nil")
        {

            myText += "Press Left to go to the " + room_west + "\n";

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                currentRoom = room_west;

            }
        }

 
        GetComponent<Text>().text = myText;

    }

}