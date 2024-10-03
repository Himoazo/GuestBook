using GuestBookApp;

// Create instance of GuestBook class
GuestBook guestbook = new GuestBook();

// While loop to always present the programs alternatives
while(true)
{
    Clear(); // Clear console
    CursorVisible = false; // Remove cursor
    WriteLine("Gästboken\n\n");
    WriteLine("1. Skriv i gästboken");
    WriteLine("2. Ta bort inlägg\n");
    WriteLine("X. Avsluta\n");

    int i = 0;
    foreach(Post post in guestbook.GetPosts())
    {
        WriteLine($"[{i++}] {post.Author} - {post.Content}"); // Print posts
    }

    int userChoice = (int) ReadKey(true).Key; // Read & store key stroke

    switch(userChoice)
    {
        case '1': // Skrive i gästboken
            //CursorVisible = true;
            Write("Skriv namnet på inläggsskrivaren: ");
            string? authorInput = ReadLine(); // Read user input
            Write("Skriv inlägg: ");
            string? textInput = ReadLine(); // Read user input
            if(!string.IsNullOrWhiteSpace(textInput) && !string.IsNullOrWhiteSpace(authorInput)) //Check if input exist 
            {
                guestbook.writePost(authorInput, textInput); // Call writePost method from GustBook type
            }
            else 
            {
                WriteLine("Inlägget och/eller inläggetsskrivaren kan inte vara tomma\n"); //Error msg
                WriteLine("Tryck på någon knapp för att försöka igen");
                ReadKey();
            }
            break;
        case '2': // Ta bort inlägg
            CursorVisible = true;
            WriteLine("Ange inläggets nummer som du vill radera: ");
            string? index = ReadLine();
            if(!string.IsNullOrEmpty(index))
            {
                try
                {
                    guestbook.deletePost(Convert.ToInt32(index)); // Call deletePost from GustBook type
                }
                catch (Exception)
                {
                    WriteLine($"Det finns inget inlägg med nummer {index}");
                    WriteLine("Tryck på någon knapp för att försöka igen");
                    ReadKey();
                }
            }
            break;
        case 88:
            Environment.Exit(0); // Exit program
            break;
    }
    
}