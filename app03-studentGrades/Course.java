/**
 * Class for creation an storage of data
 *
 * @author: Zak Smith
 * @Date: 25/10/20
 */
public class Course
{
    // Attributes for the course details.
    private String codeNo;
    private String title;

    private Module module1;
    private Module module2;
    private Module module3;
    private Module module4;
    
    private int courseMark;
    
    private String finalGrade;
    
    /**
     * Constructor for identifying details of a course
     */
    public Course(String codeNo, String title)
    {
        // initialise instance variables
        this.codeNo = codeNo;
        this.title = title;
        
        this.courseMark = 0;
        
        this.finalGrade = null;
        
        createModules();
    }
    
    /**
     * Constructor class for creating the 4 modules
     */
    public void createModules()
    {
        module1 = new Module("CO461", "3D Modelling");
        module2 = new Module("CO450", "Computer Architecture");
        module3 = new Module("CO459", "Game Design");
        module4 = new Module("CO452", "Programming Comcepts");
    }

    /**
     * class for awarding marks
     */
    public void setMark(int mark, String codeNo)
    {
        if(module1.getCodeNo() == codeNo)
        {
            module1.awardMark(mark);
        }
    }
    
    public void addModule(Module module, int moduleNo)
    {
        if(moduleNo == 1)
        {
            this.module1 = module;
            this.module2 = module;
            this.module3 = module;
            this.module4 = module;
        }
    }
    
    
    public void calculateCourseMark()
    {
        if(courseCompleted())
        {
            
           int courseMark = module1.getMark() + module2.getMark() + module3.getMark()
        
           + module4.getMark();
        
           courseMark = courseMark / 4;
        
           print();
        }
        else
        {
            
        }
    }
    
    public boolean courseCompleted()
    
    {
        if((module1.isCompleted()) && (module2.isCompleted()) && (module3.isCompleted()) 
        && (module4.isCompleted()))
        {
            return true;
        }
        else return false;
    }
    
    /**
     * Prints out the details of a course
     */
    public void print()
    {
        // put your code here
        System.out.println("Course " + codeNo + " - " + title);
    }
    
    public void printModules()
    {
        // is going to print out the final course mak
        
        if(courseCompleted())
        {
            System.out.println("Final Mark: " + courseMark);
        }
    }
}