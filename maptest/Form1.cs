using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maptest
{
    public partial class MapTest : Form
    {
        private readonly Random rand = new Random();                     //random number generator
        static readonly int maxrooms = 1000;                             //maximum number rooms
        readonly Room[] rooms = new Room[maxrooms];                      //rooms
        readonly bool[] isroom = new bool[maxrooms];                     //flags for rooms
        int numrooms, numtries, minwide, maxwide, spacer, numtunnels;    //variables for number rooms, number tries, minimum width, maximum width, spacer, and number tunnels
        bool keepgoing;                                                  //flag for continuing
        static readonly int maxtunnels = 100000;                         //maximum number tunnels
        readonly Tunnel[] tunnels = new Tunnel[maxtunnels];              //tunnels
        readonly bool[] istunnel = new bool[maxtunnels];                 //flags for tunnels
        public MapTest() //required
        {   InitializeComponent(); //required
        }

        private void GenRooms(object sender, EventArgs e) //generate rooms (button pressed)
        {   int t; //used to swap minwide and maxwide
            if (!int.TryParse(numbertries.Text, out numtries)) numtries = 5000; //set number tries from form
            if (!int.TryParse(minimumwidth.Text, out minwide)) minwide = 50; //set minimum width from form
            if (!int.TryParse(maximumwidth.Text, out maxwide)) maxwide = 100; //set maximum width from form
            if (maxwide < minwide) { t = minwide; minwide = maxwide; maxwide = t; } //if maximum width less than minimum width, swap them
            if (!int.TryParse(spaceadded.Text, out spacer)) spacer = 50; //set spacer size from form
            numrooms = 0; //number rooms = 0
            for (int i = 0; i < maxrooms; i++) isroom[i] = false; //clear all rooms
            keepgoing = true; //set flag to keep going
            while (keepgoing) //while we should keep going
            {   if (!AddRoom()) keepgoing = false; //if unable to add a room, clear keep going flag (stop)
            }
            tunnelsizetext.Enabled = true;  //Enable tunnel size text on form
            tunnelsize.Enabled = true; //Enable tunnel size on form
            gentunnels.Enabled = true; //Enable get tunnels button
            numtunnels = 0; //number tunnels = 0
            for (int i = 0; i < maxtunnels; i++) istunnel[i] = false; //clear all tunnels
            DoSort(); //sort rooms
            MapArea.Invalidate(); //redraw map area
            InfoArea.Invalidate(); //redraw info area
        }

        private bool AddRoom() //addroom routine
        {   for (int tries = 0; tries < numtries; tries++) if (TryRoom()) return true; //for each try, if room created, return
            return false; //report inability to create room
        }

        private bool TryRoom() //try to create room
        {   int maxx = 600 - minwide; //set maximum x value
            int maxy = 450 - minwide; //set maximum y value
            int s = 0; //set spacer value to 0
            int s2 = 1; //set grid size to 1
            if (addspacebetween.Checked) s = spacer; //if add space between rooms checked, set spacer to form value
            if (usespaceasgrid.Checked) s2 = spacer; //if use space as grid checked, set grid size to form value
            int x = rand.Next(s / s2, (maxx - s) / s2) * s2; //get random x value
            int rx = 600 - x - s; //get remaining x value
            if (rx > maxwide) rx = maxwide; //if remaining x value greater than maximum width, set remaining x value to maximum width
            int y = rand.Next(s / s2, (maxy - s) / s2) * s2; //get random y value
            int ry = 450 - y - s; //get remaining y value
            if (ry > maxwide) ry = maxwide; //if remaining y value greater than maximum width, set remaining y value to maximum width
            int w = rand.Next(minwide / s2, rx / s2) * s2; //get random width value
            int h = rand.Next(minwide / s2, ry / s2) * s2; //get random height value
            int swh = w; //set smaller width/height value to width
            if (h < swh) swh = h; //if height is less, set smaller width/height value to height
            if (makesquare.Checked) w = h = swh; //if make square rooms checked, set width and height to smaller width/height value
            Room room = new Room(x, y, w, h, Color.FromArgb(rand.Next(128, 256), rand.Next(128, 256), rand.Next(128, 256))); //make room
            for (int i = 0; i < maxrooms; i++) //for every room
            {   if (isroom[i]) //if room exists
                {   if (addspacebetween.Checked) //if add space between rooms checked
                    {   if (rooms[i].IsSpace(room, spacer)) return false; //if hit or hit space beween, return false (didn't work)
                    }
                    else //otherwise (add space between rooms not checked)
                    {   if (rooms[i].IsHit(room)) return false; //if hit, return false (didn't work)
                    }
                }
            }
            for (int i = 0; i < maxrooms; i++)  //find first room
            {   if (!isroom[i]) //if room doesn't exist
                {   rooms[i] = room; //set room to temporary room
                    numrooms++; //increment number rooms
                    isroom[i] = true; //set flag to show room now exists
                    return true; //return true (room created)
                }
            }
            return false; //return false (couldn't make new room)
        }

        private void DoSort() //sort rooms routine
        {   for (int i = 0; i < maxrooms - 1; i++) //for each room until the last one
            {   for (int j = i + 1; j < maxrooms; j++) //for each room after previous room
                {   if (DoCompare(i, j) < 0) DoSwap(i, j); //if second room "less than" first room, swap rooms
                }
            }
        }

        private int DoCompare(int i, int j) //compare rooms routine
        {   if (isroom[i]) //if first room exists
            {   if (isroom[j]) //if second room exists
                {   if (rooms[i].X == rooms[j].X) //if they are both equal horzontally
                    {   if (rooms[i].Y == rooms[j].Y)  return 0; //if they are equal vertically, return equal
                        if (rooms[i].Y < rooms[j].Y) return 1; //if first room less than second room, return less
                        return -1; //return more as second room is less than first
                    }
                    if (rooms[i].X < rooms[j].X) return 1; //if first room is less than second room, return less
                    return -1; //return more as second room is less than first
                }
                else return 1; //otherwise (second room doesn't exist), return less
            }
            else //otherwise (first room doesn't exist)
            {   if (isroom[j]) return -1; //if second room exists, return more
            }
            return 1; //return less
        }

        private void DoSwap(int i, int j) //swap rooms routine
        {   Room tr = rooms[j]; //set temp room to second room
            rooms[j] = rooms[i]; //set second room to first room
            rooms[i] = tr; //set first room to temp room
            bool tb = isroom[j]; //set temp flag to second room flag
            isroom[j] = isroom[i]; //set second room flag to first room flag
            isroom[i] = tb; //set first room flag to temp flag
        }

        private void ExitProgram(object sender, EventArgs e) //exit program (button pressed)
        {   Application.Exit(); //exit program
        }

        private void PaintMap(object sender, PaintEventArgs e) //paint (redraw) map area
        {   for (int i = 0; i < maxtunnels; i++) if (istunnel[i]) tunnels[i].Paint(e); //paint all tunnels
            for (int i = 0; i < maxrooms; i++) if (isroom[i]) rooms[i].Paint(e); //paint all rooms
        }

        private void PaintInfo(object sender, PaintEventArgs e) //paint (redraw) info area
        {   Font font = new Font("Arial Black", 10, FontStyle.Bold); //set up font (Arial Black, 10 points, bold)
            SolidBrush brush = new SolidBrush(Color.White); //use white text
            RectangleF rect = new RectangleF(0, 0, 200, 130); //set up rectangle for where to write
            e.Graphics.DrawString($"{numrooms} rooms and {numtunnels} tunnel squares generated.", font, brush, rect); //write information
        }

        private void GenerateTunnels(object sender, EventArgs e) //generate tunnels (button pressed)
        {   if (!int.TryParse(tunnelsize.Text, out int size)) size = 24; //get tunnel size from form
            numtunnels = 0; //set number tunnels to 0
            Tunnel path, endpath; //temporary tunnels storage
            for (int i = 0; i < maxtunnels; i++) istunnel[i] = false; //clear all tunnels
            int first = 0; //set first to 0
            for (int i = 0; i < maxrooms; i++) //use first room
            {   if (isroom[i]) //if room exists
                {   first = i; //set first to room number
                    i = maxrooms; //exit loop
                }
            }
            keepgoing = true; //set keep going flag to true
            while (keepgoing) //while we are supposed to keep going
            {   int next = 0; //set next room to 0
                for (int i = first + 1; i < maxrooms; i++) //use first room (after first)
                {   if (isroom[i]) //if room exists
                    {   next = i; //set next to room number
                        i = maxrooms; //exit loop
                    }
                }
                if (next == 0) keepgoing = false; //if there was no next room, we are done
                else //otherwise (keep going)
                {   int dist = rooms[next].GetDistance(rooms[first]); //get distance from first room to next room
                    for (int i = first-1; i > -1;i--) //check all rooms before first room (already processed rooms)
                    {   if (rooms[next].GetDistance(rooms[i]) < dist) //if room is at a shorter distance
                        {   first = i; //set first to that room number
                            dist = rooms[next].GetDistance(rooms[first]); //set that room's distance for further testing
                        }
                    }
                    rooms[first].GetDir(rooms[next], out int xdir, out int ydir); //get hint for direction
                    if (Math.Abs(xdir) > Math.Abs(ydir)) //if x distance is greater than y distance
                    {   if (xdir > 0) //if x direction is positive
                        {   path = new Tunnel(rooms[first].LastX() + 1, rooms[first].MidY() - size / 2, size); //make first tunnel
                            path = AddTunnel(path, 0, 0); //add it to tunnels
                            path = AddTunnel(path, size, 0); //add next tunnel
                            endpath = new Tunnel(rooms[next].X - size + 1, rooms[next].MidY() - size / 2, size); //make end tunnel
                        }
                        else //otherwise (x direction is negative)
                        {   path = new Tunnel(rooms[first].X - size + 1, rooms[first].MidY() - size / 2, size); //make first tunnel
                            path = AddTunnel(path, 0, 0); //add it to tunnels
                            path = AddTunnel(path, -size, 0); //add next tunnel
                            endpath = new Tunnel(rooms[next].LastX() + 1, rooms[next].MidY() - size / 2, size); //make end tunnel
                        }
                    }
                    else //otherwise (y distance greater than x distance)
                    {   if (ydir > 0) //if y direction is positive
                        {   path = new Tunnel(rooms[first].MidX() - size / 2, rooms[first].LastY() + 1, size); //make first tunnel
                            path = AddTunnel(path, 0, 0); //add it to tunnels
                            path = AddTunnel(path, 0, size); //add next tunnel
                            endpath = new Tunnel(rooms[next].MidX() - size / 2, rooms[next].Y - size + 1, size); //make end tunnel
                        }
                        else //otherwise (y direction is negative)
                        {   path = new Tunnel(rooms[first].MidX() - size / 2, rooms[first].Y - size + 1, size); //make first tunnel
                            path = AddTunnel(path, 0, 0); //add it to tunnels
                            path = AddTunnel(path, 0, -size); //add next tunnel
                            endpath = new Tunnel(rooms[next].MidX() - size / 2, rooms[next].LastY() + 1, size); //make end tunnel
                        }
                    }
                    while (!path.IsHit(rooms[next])) //while tunnel has not reached next room
                    {   path.GetDir(endpath, out xdir, out ydir); //get hint for direction to end tunnel
                        if ((xdir < size) && (-size < xdir) && (ydir < size) && (-size < ydir)) path.GetDir(rooms[next], out xdir, out ydir); //if end tunnel too close, use next room
                        if (Math.Abs(xdir) > Math.Abs(ydir)) //if x distance greater than y distance
                        {   if (xdir > 0) path = AddTunnel(path, size, 0); //if x direction positive, add tunnel that way
                            else path = AddTunnel(path, -size, 0); //otherwise (x direction negative), add tunnel that way
                        }
                        else //otherwise (y distance greater than x distance)
                        {   if (ydir > 0) path = AddTunnel(path, 0, size); //if y direction position, add tunnel that way
                            else path = AddTunnel(path, 0, -size); //otherwise (y direction negative), add tunnel that way
                        }
                    }
                    first = next; //set first room to next room (set as processed)
                }
            }
            MapArea.Invalidate(); //redraw map area
            InfoArea.Invalidate(); //redraw information area
        }

        private Tunnel AddTunnel(Tunnel last, int xd, int yd) //add tunnel routine
        {   Tunnel next = new Tunnel(last.X + xd, last.Y + yd, last.W); //set next tunnel to previous tunnel with x and y adjustments
            for (int i = 0; i < maxtunnels; i++) //find first available tunnel
            {   if (!istunnel[i]) //if tunnel doesn't exist (is available)
                {   tunnels[i] = next; //set tunnel to next tunnel
                    istunnel[i] = true; //set tunnel flag to show tunnel exists now
                    numtunnels++; //increment number tunnels
                    i = maxtunnels; //exit loop
                }
            }
            return next; //return next tunnel
        }

    }
}

public class Room //room class
{   public int X, Y, W, H; //storage for dimensions (publicly available)
    public Color C; //storage for color (publicly available)
    public Room(int x, int y, int w, int h, Color c) //initialize funtion
    {   X = x; //copy X value to storage
        Y = y; //copy Y value to storage
        W = w; //copy Width value to storage
        H = h; //copy Height value to storage
        C = c; //copy Color value to storage
    }
    public bool IsHit(int x, int y, int w, int h) //public method for hit testing
    {   if (x + w < X) return false; //if too far left, return false (no hit)
        if (x > X + W) return false; //if too far right, return false (no hit)
        if (y + h < Y) return false; //if too far up, return false (no hit)
        if (y > Y + H) return false; //if too far down, return false (no hit)_
        return true; //otherwise, return true (hit)
    }
    public int MidX() //public method to get middle X position
    {   return X + W / 2 - 1; //return middle X position
    }
    public int MidY() //public method to get middle Y position
    {   return Y + H / 2 - 1; //return middle Y position
    }
    public int LastX() //public method to get last X position
    {   return X + W - 1; //return last X position
    }
    public int LastY() //public method to get last Y position
    {   return Y + H - 1; //return last Y position
    }
    public int GetDistance(Room r) //public method to return distance from another room
    {   int xd = Math.Abs(r.MidX() - MidX()); //get X distance
        int yd = Math.Abs(r.MidY() - MidY()); //get Y distance
        return (int)Math.Sqrt(xd * xd + yd * yd); //compute actual distance and return it
    }
    public void GetDir(Room r, out int xdir, out int ydir) //public method to return X direction and Y direction to another room
    {   xdir = r.MidX() - MidX(); //get X direction
        ydir = r.MidY() - MidY(); //get Y direction
    }
    public bool IsHit(Room r) => IsHit(r.X, r.Y, r.W, r.H); //public method to hit test another room
    public bool IsSpace(int x, int y, int w, int h, int space) //public method to test for hit including spacer
    {   if (x + w + space < X) return false; //if too far left, return false (no hit)
        if (x > X + W + space) return false; //if too far right, return false (no hit)
        if (y + h + space < Y) return false; //if too far up, return false (no hit)
        if (y > Y + H + space) return false; //if too far down, return false (no hit)
        return true; //otherwise, return true (hit)
    }
    public bool IsSpace(Room r, int space) => IsSpace(r.X, r.Y, r.W, r.H, space); //public method to test for hit including spacer for another room
    public void Paint(PaintEventArgs e) //public method to paint room
    {   SolidBrush brush = new SolidBrush(C); //set up brush to fill the room with supplied color
        Pen pen = new Pen(Color.White); //use white for borders
        e.Graphics.FillRectangle(brush, X, Y, W, H); //fill the room
        e.Graphics.DrawRectangle(pen, X, Y, W, H); //draw the borders
    }
}

public class Tunnel : Room //public class for tunnel which is derived from room
{   public Tunnel(int x, int y, int size) : base(x,y,size,size,Color.FromArgb(32,32,32)) //set tunnel initialize function to use room initialize function
    { 
    }
}
