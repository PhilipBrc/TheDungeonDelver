VAR torches = 0
VAR gold = 0
VAR weapon = 0
VAR time = 0
-> TheStart
=== TheStart
The light ahead of the tunnel shines bright, looking forward causes your eyes to adjust
-> TheFirstPath


= TheFirstPath
You face a path, the right path seems to lead to a dark woods, while the left goes into a rising hill.
* You Go Right.
    You decide to go right, and find that the pathway begins to show much disrepair, as nature seems to be at the edge of reclaiming it.
    There is no noise past the soft winds rustling the leaves. The darkness drapes a cooling shade over you, and the little bits of light that does shine through the crown of the canopy gives you a suitable ammount of visibility.
    ** Look around.
        You look around and see a glint come off from where of the sun rays is landing. 
        You found a dagger!
        ~weapon = weapon+1
        You continue on the path and find yourself out of the forest, and into a charred battlefield.
        It looks to be devoid of animal life, and its dead silence confirms that nothing alive has made itself known here.
        *** Move Forward
            You decide its best to move forward.
            ->ResultRightBattlefield
        *** Go Back
            As you turn to go back, you could swear you saw something shift in the bushes, but didn't hear anything.
            **** Look for it
                You decide to look for the source of the noise, you can't seem to find the source.
                Suddenly you hear a snap, as a wolf jumps out from the bushes of the woods.
                -> ResultRightAmbush
                
            **** Turn back and go through the battlefield
                You decided its best to move forward.
                -> ResultRightBattlefield
            **** Run back through the forest
                You decide to go back through the forst, in a rush as to not deal with whatever that was about.
                Suddenly you hear a snap, as a wolf jumps out from the bushes of the woods.
                ->ResultRightAmbush
            **** Walk back through the forest
                You decide to go back through the forest, rather than take a chance with whatever might be past the field.
                Eventually you find yourself back where you started.
                -> TheFirstPath
        
* You Go Left.
    You decide to go left and take the path on the hill.
    Once you reach the top you see the entrace to a big city in the distance, although you don't recognise where you are from it.
    ** Continue onwards.
        You continue moving to the town, when you hear a noise come from the bushes.
        A wolf jumps you.
        Insert fight here.
        ->DONE
    ** Choose a different path.
        You decide to take a different path and go back.
        ->TheFirstPath
    You continue on to the big city, hopefully it's inhabitants aren't hostile.
    ->ResultLeftCity
*You look back in the cave.
    There is a small coin left behind inside. You pick it up.
    ~gold = gold + 1
    You got 1 gold.
    There doesn't seem to be much else to the cave. The inside collapsed from when you left.
-> TheFirstPath

= ResultRightBattlefield
Some Exploration Happens
Insert Dungeon Possibility Here
-> DONE

= ResultRightAmbush
Insert Fight Here
-> DONE

= ResultLeftCity
Insert Stuff Here
-> DONE