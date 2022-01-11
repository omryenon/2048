using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048 : MonoBehaviour
{
    public Cell2048 left;
    public Cell2048 right;
    public Cell2048 up;
    public Cell2048 down;

    public Fill2048 fill;

    private void OnEnable()
    {
        GameController2048.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameController2048.slide -= OnSlide;
    }

    private void OnSlide(string inp)
    {
        CellCheck();
        //Debug.Log(inp);
        // moving up:
        if (inp == "w")
        {
            //check if this Cell is one of the top cells. We would like to reach the upper cell and from this one to go down...
            if (up != null)
                return;
            Cell2048 currCell = this;
            SlideUp(currCell);
        }
        else if (inp == "d")
        {
            //check if this Cell is one of the top cells. We would like to reach the upper cell and from this one to go down...
            if (right != null)
                return;
            Cell2048 currCell = this;
            SlideRight(currCell);
        }
        else if (inp == "s")
        {
            //check if this Cell is one of the top cells. We would like to reach the upper cell and from this one to go down...
            if (down != null)
                return;
            Cell2048 currCell = this;
            SlideDown(currCell);
        }
        else if (inp == "a")
        {
            //check if this Cell is one of the top cells. We would like to reach the upper cell and from this one to go down...
            if (left != null)
                return;
            Cell2048 currCell = this;
            SlideLeft(currCell);
        }

        GameController2048.ticker++;
        /// Just the cells that are on the edge won't return and increase the ticker. After it will be 4 we know all cells moved.
        if (GameController2048.ticker == 4)
            GameController2048.instance.LocateNumOnGrid();
    }

    ///Up////////////////////////////////////////////////////////////////////////////////////
    void SlideUp(Cell2048 curr)
    {
        //Debug.Log(curr.gameObject);
        if (curr.down == null)
            return;
        if (curr.fill != null)
        {
            Cell2048 next = curr.down;
            // if we are at the end of the grid or we reached a filled cell we break the loop.
            while (next.down != null && next.fill == null)
                next = next.down;
            if (next.fill != null)
            {
                // that means we reached the first cell with value lets see if it's value equals to our cur top cell
                if (curr.fill.value == next.fill.value)
                {
                    next.fill.Double();
                    next.fill.transform.SetParent(curr.transform);
                    curr.fill = next.fill ; 
                    next.fill = null;
                }
                else if(curr.down.fill != next.fill)
                {
                    //Debug.Log("Different Values!");
                    next.fill.transform.SetParent(curr.down.transform);
                    curr.down.fill = next.fill;  
                    next.fill = null;
                }
            }
            // else, we are at the end of the grid and this cell is empty - nothing to do here
        }
        else
        {
            Cell2048 next = curr.down;
            while (next.down != null && next.fill == null)
                next = next.down;
            if (next.fill != null)
            {
                //that means we reached the first cell with value, lets move it to our curr cell 
                next.fill.transform.SetParent(curr.transform);
                curr.fill = next.fill;
                next.fill = null;
                //now, after it has a new value, lets start this function again
                SlideUp(curr);
                //Debug.Log("Slide valued cell to an empty one");
            }
        }
            if (curr.down == null)
            return;
        SlideUp(curr.down);
    }
    /////////Right///////////////////////////////////////////////////////////////////////////////////////////////
    void SlideRight(Cell2048 curr)
    {
        //Debug.Log(curr.gameObject);
        if (curr.left == null)
            return;
        if (curr.fill != null)
        {
            Cell2048 next = curr.left;
            // if we are at the end of the grid or we reached a filled cell we break the loop.
            while (next.left != null && next.fill == null)
                next = next.left;
            if (next.fill != null)
            {
                // that means we reached the first cell with value lets see if it's value equals to our cur top cell
                if (curr.fill.value == next.fill.value)
                {
                    next.fill.Double();
                    next.fill.transform.SetParent(curr.transform);
                    curr.fill = next.fill; 
                    next.fill = null;
                }
                else if (curr.left.fill != next.fill)
                {
                    //Debug.Log("Different Values!");
                    next.fill.transform.SetParent(curr.left.transform);
                    curr.left.fill = next.fill;
                    next.fill = null;
                }
            }
            // else, we are at the end of the grid and this cell is empty - nothing to do here
        }
        else
        {
            Cell2048 next = curr.left;
            while (next.left != null && next.fill == null)
                next = next.left;
            if (next.fill != null)
            {
                //that means we reached the first cell with value, lets move it to our curr cell 
                next.fill.transform.SetParent(curr.transform);
                curr.fill = next.fill;
                next.fill = null;
                //now, after it has a new value, lets start this function again
                SlideRight(curr);
                //Debug.Log("Slide valued cell to an empty one");
            }
        }
        if (curr.left == null)
            return;
        SlideRight(curr.left);
    }

    /////////Left///////////////////////////////////////////////////////////////////////////////////////////////
    void SlideLeft(Cell2048 curr)
    {
        //Debug.Log(curr.gameObject);
        if (curr.right == null)
            return;
        if (curr.fill != null)
        {
            Cell2048 next = curr.right;
            // if we are at the end of the grid or we reached a filled cell we break the loop.
            while (next.right != null && next.fill == null)
                next = next.right;
            if (next.fill != null)
            {
                // that means we reached the first cell with value lets see if it's value equals to our cur top cell
                if (curr.fill.value == next.fill.value)
                {
                    next.fill.Double();
                    next.fill.transform.SetParent(curr.transform);
                    curr.fill = next.fill; 
                    next.fill = null;
                }
                else if (curr.right.fill != next.fill)
                {
                    //Debug.Log("Different Values!");
                    next.fill.transform.SetParent(curr.right.transform);
                    curr.right.fill = next.fill;
                    next.fill = null;
                }
            }
            // else, we are at the end of the grid and this cell is empty - nothing to do here
        }
        else
        {
            Cell2048 next = curr.right;
            while (next.right != null && next.fill == null)
                next = next.right;
            if (next.fill != null)
            {
                //that means we reached the first cell with value, lets move it to our curr cell 
                next.fill.transform.SetParent(curr.transform);
                curr.fill = next.fill;
                next.fill = null;
                //now, after it has a new value, lets start this function again
                SlideLeft(curr);
                //Debug.Log("Slide valued cell to an empty one");
            }
        }
        if (curr.right == null)
            return;
        SlideLeft(curr.right);
    }

    /////////Down///////////////////////////////////////////////////////////////////////////////////////////////
    void SlideDown(Cell2048 curr)
    {
        //Debug.Log(curr.gameObject);
        if (curr.up == null)
            return;
        if (curr.fill != null)
        {
            Cell2048 next = curr.up;
            // if we are at the end of the grid or we reached a filled cell we break the loop.
            while (next.up != null && next.fill == null)
                next = next.up;
            if (next.fill != null)
            {
                // that means we reached the first cell with value lets see if it's value equals to our cur top cell
                if (curr.fill.value == next.fill.value)
                {
                    next.fill.Double();
                    next.fill.transform.SetParent(curr.transform);
                    curr.fill = next.fill; 
                    next.fill = null;
                }
                else if (curr.up.fill != next.fill)
                {
                    //Debug.Log("Different Values!");
                    next.fill.transform.SetParent(curr.up.transform);
                    curr.up.fill = next.fill;
                    next.fill = null;
                }
            }
            // else, we are at the end of the grid and this cell is empty - nothing to do here
        }
        else
        {
            Cell2048 next = curr.up;
            while (next.up != null && next.fill == null)
                next = next.up;
            if (next.fill != null)
            {
                //that means we reached the first cell with value, lets move it to our curr cell 
                next.fill.transform.SetParent(curr.transform);
                curr.fill = next.fill;
                next.fill = null;
                //now, after it has a new value, lets start this function again
                SlideDown(curr);
                //Debug.Log("Slide valued cell to an empty one");
            }
        }
        if (curr.up == null)
            return;
        SlideDown(curr.up);
    }

    void CellCheck()
    {
        if (fill == null)
            return;
        if(up != null)
        {
            if (up.fill == null)
                return;
            if (up.fill.value == fill.value)
                return;
        }
        if (down != null)
        {
            if (down.fill == null)
                return;
            if (down.fill.value == fill.value)
                return;
        }
        if (left != null)
        {
            if (left.fill == null)
                return;
            if (left.fill.value == fill.value)
                return;
        }
        if (right != null)
        {
            if (right.fill == null)
                return;
            if (right.fill.value == fill.value)
                return;
        }
        /// if we here that means that this cell is filled and blocked in the all directions with other cells with different values
        GameController2048.instance.GameOver();
    }
}
