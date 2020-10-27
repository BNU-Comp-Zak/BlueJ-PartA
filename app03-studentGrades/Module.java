/**
 * Write a description of class Module here.
 *
 *@author: Zak Smith
 * @Date: 25/10/20
 */
public class Module
{
    // Fields
    private String title;
    
    private String codeNo;
    
    private int mark;
    
    private int credit;
    
    private boolean passed;
    
    private boolean completed;
    
    /**
     * Constructor for objects of class Module
     */
    public Module(String title, String codeNo)
    {
        this.title = title;
        this.codeNo = codeNo;
        
        mark = -1;
        credit = 15;
        
        passed = false;
        completed = false;
    }
    
    public void awardMark(int mark)
    {
        this.mark = mark;
    }
    
    public int getMark()
    {
        return mark;
    }

    public String getCodeNo()
    {
        return codeNo;
    }
    
    /**
     *  This will return a mark if its greater or equal to 0 when the course is completed.
     */
    public boolean isCompleted()
    {
        return mark >= 0;
    }
    
    public void print()
    {
        System.out.println("Module: " + title + " " + codeNo + " Mark = " + mark);
    }
}