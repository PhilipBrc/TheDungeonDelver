EXTERNAL setGold(int x)
VAR x = 0
->Start

===Start

The light ahead of the tunnel shines, you look forward.
->FirstPath

=FirstPath
You walk out to a path with two ways, right into the dark woods, or left up a hill.

*Go Right.
    You decide to go right, and find that the pathway begins to show much disrepair, as nature seems to be at the edge of reclaiming it.
    ->DONE

* Go Left.
    You decide to go left and take the path on the hill.
    Once you reach the top you see the entrace to a big city in the distance, although you don't recognise where you are from it.
    There is a beggar on the road asleep.
    {x:
    **Go forward.
        You go forward to the city.
        ->DONE
    **Give gold.
        You give the beggar a gold
        ~ x = x-1
        ~setGold(x)
        ->DONE
    - else:
        **Move Along
            You move along
            ->DONE
    }
    ->DONE
    
    ->DONE
    
*Look back in the cave.
    There is a small coin left behind inside. You pick it up.
    You got 1 gold.
    There doesn't seem to be much else to the cave.
    ~ x = x+1
    ~setGold(x)
    ->FirstPath