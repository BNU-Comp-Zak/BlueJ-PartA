
/**
 * Write a description of class Course here.
 *
 * @author (Zak Smith)
 * 
 */
public class Course
{
    // The Course code
    private String codeNumber;
    // The Course title
    private String title;

    /**
     * Creates a new course
     */
    public Course(String title, String codeNumber)
    {
        this.codeNumber = codeNumber;
        this.title = title;
        
        
    }
    
    public void print()
    {
        System.out.println("Course: " + title + "" + codeNumber);
    }
    
    }

