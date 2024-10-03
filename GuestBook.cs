using System.Text.Json;

namespace GuestBookApp;
// GuestBook type
public class GuestBook
{
    private string bookFile = "guestbook.json"; //Json file which stores posts

    private List<Post> posts = new List<Post>(); // Post list
    // Constructor to establish instance of GuestBook type
    public GuestBook ()
    {
        if(File.Exists(bookFile))
        {
            string guestFile = File.ReadAllText(bookFile); // Read and store json file content
            posts = JsonSerializer.Deserialize<List<Post>>(guestFile)!; // Iterate over the JSON entries and put them into list
        }
    }
    // Create post method
    public Post writePost(string postAuthor, string postText)
    {
        Post insertion = new Post(); // Post type instance
        insertion.Author = postAuthor;
        insertion.Content = postText;
        posts.Add(insertion); //Add the new post to posts list
        saveToJson(); // Save
        return insertion;
    }
    // Render all saved posts in the list
    public List<Post> GetPosts ()
    {
        return posts;
    }
    // Delete post method
    public int deletePost(int index)
    {
        posts.RemoveAt(index); // Delete from List at given index
        saveToJson(); //Save
        return index;
    }
    // Save to json file method
    private void saveToJson()
    {
        string data = JsonSerializer.Serialize(posts); //Convert data to Json
        File.WriteAllText(bookFile, data); // Write json data in json file
    }
}