using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Collections;

namespace BattleShipsServer
{
    [Serializable]
    public class BattleGrid
    {
        private int HorizontalSquareCount;
        private int VerticalSquareCount;
        private int squarePixelWidth;
        private EnumBattleGridSquare [,] SquaresArray;
        //private System.Windows.Forms.PictureBox gridPicBox;
        [NonSerialized]
        private Graphics gridPicGraphics;
        [NonSerialized]private ResourceManager resManager;
        [NonSerialized]
        private Fleet fleet;
        [NonSerialized]
        private Bitmap bmpGridImage;

        // initialise battlegrid
        // note theres no reset method, if you want to reset the battlegrid
        // just create a new instance of battleGrid
        public BattleGrid(int VerticalSquareCount, int HorizontalSquareCount, Bitmap gridBitmap, int squarePixelWidth)
        {
            this.VerticalSquareCount = VerticalSquareCount;
            this.HorizontalSquareCount = HorizontalSquareCount;
            SquaresArray = new EnumBattleGridSquare[VerticalSquareCount, HorizontalSquareCount];
            
            for(int row=0; row < SquaresArray.GetLength(0); row++)
                for(int column= 0; column < SquaresArray.GetLength(1); column++)
                    SquaresArray[row, column]=EnumBattleGridSquare.WaterUnhit;

            //this.gridPicBox=gridPicBox;
            this.squarePixelWidth = squarePixelWidth;
            //gridPicGraphics = gridPicBox.CreateGraphics();

            initGridResources(gridBitmap);

            // for server automoves initialisation
            for (int row = 0; row < SquaresArray.GetLength(0); row++)
                for (int column = 0; column < SquaresArray.GetLength(1); column++)
                    freeServerMovesToMake.Add(new Point(column, row));
        }

        public void initGridResources(Bitmap gridBitmap)
        {
            bmpGridImage = gridBitmap;
            gridPicGraphics = Graphics.FromImage(gridBitmap);
            gridPicGraphics.Clear(Color.FromArgb(128, 128, 255));

            resManager = new ResourceManager("BattleShipsServer.BattleGridSquareImages", GetType().Assembly);
            DrawGrid();
        }

        private EnumBattleGridSquare checkGridSquare(Point coord)
        {
            return SquaresArray[coord.Y, coord.X];
        }

        public Bitmap gridBmapImage
        {
            get
            {
                return this.bmpGridImage;
            }
        }

        // updates grid squares to reflect exactly which squares
        // are marked as EnumBattleGridSquare.Ship
        // return true if the position is allowable eg not already
        // positioned by another ship using the same space.
        private bool InsertShipIntoGrid(Ship ship)
        {
            if (!shipWithinBounds(ship)) return false;

            if (ShipAlreadyInserted(ship.StartCoordinate, ship))return false;

            for (int shipPartNo = 0; shipPartNo < ship.MaxHitsRequired; shipPartNo++)
            {
                if (ship.ShipOrientation == EnumShipOrientation.Horizontal)
                    SquaresArray[ship.StartCoordinate.Y, ship.StartCoordinate.X+shipPartNo] = EnumBattleGridSquare.Ship;
                else
                    SquaresArray[ship.StartCoordinate.Y+shipPartNo, ship.StartCoordinate.X] = EnumBattleGridSquare.Ship;
            }

            return true;
        }

        private bool shipWithinBounds(Ship ship)
        {
            if (ship.ShipOrientation == EnumShipOrientation.Horizontal)
                if (ship.StartCoordinate.X + ship.MaxHitsRequired >= HorizontalSquareCount)
                    return false;
            else if (ship.ShipOrientation == EnumShipOrientation.Vertical)
                if (ship.StartCoordinate.Y + ship.MaxHitsRequired >= VerticalSquareCount)
                    return false;

            return true;
        }

        // checks if specified position for ship is already being used on grid
        // return false if ship position specified is not already used
        // return true otherwise
        private bool ShipAlreadyInserted(System.Drawing.Point coord, Ship ship)
        {
            for (int shipPartNo = 0; shipPartNo < ship.MaxHitsRequired; shipPartNo++)
            {
                if (ship.ShipOrientation == EnumShipOrientation.Horizontal)
                {
                    if (SquaresArray[ship.StartCoordinate.Y, ship.StartCoordinate.X+shipPartNo] == EnumBattleGridSquare.Ship)
                        return true;
                }
                else
                {
                    if (SquaresArray[ship.StartCoordinate.Y + shipPartNo, ship.StartCoordinate.X] == EnumBattleGridSquare.Ship)
                        return true;
                }
            }

            return false;
        }

        // server method
        // update battle grid to reflect where shot was fired,
        // return null if the spot was already shot at, eg
        // this could catch that a shot is not allowed to happen
        public EnumBattleGridSquare? FireShot(System.Drawing.Point coord)
        {
            if (SquaresArray[coord.Y, coord.X] == EnumBattleGridSquare.Ship)
            {
                SquaresArray[coord.Y, coord.X] = EnumBattleGridSquare.ShipHit;
                
                Ship ship;
                if ((ship = fleet.GetShip(coord)) != null)
                    ship.setShipHit();

                return EnumBattleGridSquare.ShipHit;
            }
            else if (SquaresArray[coord.Y, coord.X] == EnumBattleGridSquare.WaterUnhit)
            {
                SquaresArray[coord.Y, coord.X] = EnumBattleGridSquare.WaterHit;
                return EnumBattleGridSquare.WaterHit;
            }
            else
                return null;
        }

        // convert our screen position to a mapable grid coordinate
        // return null if invalid position selected
        // ptPicBox = ptPicBox point of our picturebox we selected
        // ptMousePos = mouse point of where we clicked on the picturebox/form
        public static Point? ConvertPicPositionToGridCoordinate(Point ptPicBox, Point ptMousePos, int squarePixelWidth)
        {
		    //Create a point to store where we clicked in the picture box
            Point pt_Clicked_On_PicBox = new Point();
		    //Calculate the values of the x & y coordinates of the mouse click relative to the picture box
		    pt_Clicked_On_PicBox.X = ptMousePos.X-ptPicBox.X;
		    pt_Clicked_On_PicBox.Y = ptMousePos.Y-ptPicBox.Y;

		    if ((pt_Clicked_On_PicBox.X % squarePixelWidth ==0) || (pt_Clicked_On_PicBox.Y % squarePixelWidth ==0))
		        // invalid move position
			    return null;

            return new Point((pt_Clicked_On_PicBox.X) / squarePixelWidth, (pt_Clicked_On_PicBox.Y) / squarePixelWidth);
        }

        // this method converts a grid coordinate into a absolute point
        // matching the pictbox on the screen
        private static Point? ConvertGridCoordToPicPosition(Point coord, int squarePixelWidth)
        {
            Point ptToDrawAt = new Point();

            ptToDrawAt.X = coord.X * squarePixelWidth + 1;
            ptToDrawAt.Y = coord.Y * squarePixelWidth + 1;

            return ptToDrawAt;
        }


        // client end method
        // use when client receives a shot command from server
        public void shotFired(bool shipHit, System.Drawing.Point coord)
        {
            SquaresArray[coord.Y, coord.X] = shipHit?EnumBattleGridSquare.ShipHit:EnumBattleGridSquare.WaterHit;
            drawFiredState(shipHit, coord);
        }

        private void drawFiredState(bool shipHit, System.Drawing.Point coord)
        {
            Point? ptToDrawAt = ConvertGridCoordToPicPosition(coord, squarePixelWidth);

            if(ptToDrawAt.HasValue)
            {
                Image m_image=null;

                if (shipHit)
                    m_image = (Image)resManager.GetObject("shiphit");
                else
                    m_image = (Image)resManager.GetObject("waterhit");
			
                //Use windows GDI commands to draw the image at the top left of the grid selected
                this.gridPicGraphics.DrawImage(m_image, ptToDrawAt.Value);
            }
        }

        // draw state of entire battlegrid table
        // CHANGED - taken out drawfleet so it only draws shots states
        public void DrawIt()
        {
     //       DrawFleet();

            for (int row = 0; row < SquaresArray.GetLength(0); row++)
            {
                for (int column = 0; column < SquaresArray.GetLength(1); column++)
                {
                    if(SquaresArray[row, column]==EnumBattleGridSquare.ShipHit)
                        drawFiredState(true, new Point(column, row));
                    else if(SquaresArray[row, column]==EnumBattleGridSquare.WaterHit)
                        drawFiredState(false, new Point(column, row));
                }
            }
        }

        private void DrawGrid()
        {
            //This method simply draws a line horizontally and vertically every 17 pixels the picture box

            //Note the value 170 is the width/height of our picture box. 
            //You will want to create a larger picture box for assignment 3

	        Brush m_Brush=Brushes.Black; //drawing object used for drawing the hang man
            Pen m_pen = new Pen(m_Brush, 1);		//Pen is used when drawing lines

            int GridPixelsWidth = squarePixelWidth * HorizontalSquareCount;

            for (int i = squarePixelWidth; i < GridPixelsWidth; i += squarePixelWidth)
            {
                //Draw along the x axis
                gridPicGraphics.DrawLine(m_pen, i, 0, i, GridPixelsWidth);
                //Draw along the y axis
                gridPicGraphics.DrawLine(m_pen, 0, i, GridPixelsWidth, i);
            }
        }


        // draw fleet on pic

        // be carefull with this method, only use when its your own fleet
        // we should not allow to see opponents fleet
        public void DrawFleet(Fleet fleet)
        {
            Image m_image=null;

            foreach (Ship ship in fleet.Ships)
            {
                Point currentCoord; 

                for(int shipPart=0; shipPart < ship.MaxHitsRequired; shipPart++) 
                {
                    if(ship.ShipOrientation== EnumShipOrientation.Vertical)
                        currentCoord=new Point(ship.StartCoordinate.X, ship.StartCoordinate.Y+shipPart);
                    else
                        currentCoord=new Point(ship.StartCoordinate.X+shipPart, ship.StartCoordinate.Y);

                    if(shipPart==0)
                    {
                        if(ship.ShipOrientation== EnumShipOrientation.Vertical)
                            m_image=(Image)resManager.GetObject("vertShipBack");
                        else
                            m_image=(Image)resManager.GetObject("horizShipBack");
                    }
                    else if (shipPart == ship.MaxHitsRequired - 1)
                    {
                        if (ship.ShipOrientation == EnumShipOrientation.Vertical)
                            m_image = (Image)resManager.GetObject("vertShipFront");
                        else
                            m_image = (Image)resManager.GetObject("horizShipFront");
                    }
                    else
                    {
                        if (ship.ShipOrientation == EnumShipOrientation.Vertical)
                            m_image = (Image)resManager.GetObject("vertShipBody");
                        else
                            m_image = (Image)resManager.GetObject("horizShipBody");
                    }

                    Point ptToDrawAt=ConvertGridCoordToPicPosition(currentCoord, 17).Value;

                    //Use windows GDI commands to draw the image at the top left of the grid selected
                    this.gridPicGraphics.DrawImage(m_image, ptToDrawAt);
                }

            }

        }

        public void DrawFleet()
        {
            try
            {
                DrawFleet(fleet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // this method automatically generates ship positions on the grid and inserts them
        // this method should only be included in the servers definition of BattleGrid
        // not the clients
        public void RandomlyInsertShips(Fleet fleet)
        {
            foreach (Ship ship in fleet.Ships)
            {
                do
                {
                    Random rnd = new Random();

                    int orientation = (new Random()).Next(2);

                    ship.ShipOrientation = orientation == 0 ? EnumShipOrientation.Horizontal : EnumShipOrientation.Vertical;

                    int xCoord;
                    int yCoord;

                    if (ship.ShipOrientation == EnumShipOrientation.Vertical)
                    {
                        yCoord = rnd.Next(16 - ship.MaxHitsRequired);
                        xCoord = rnd.Next(16);
                    }
                    else
                    {
                        xCoord = rnd.Next(16 - ship.MaxHitsRequired);
                        yCoord = rnd.Next(16);
                    }

                    ship.StartCoordinate = new System.Drawing.Point(xCoord, yCoord);
                }
                while (!InsertShipIntoGrid(ship));
            }

            this.fleet = fleet;
        }

        ArrayList lastServerMovesMade= new ArrayList();
        ArrayList freeServerMovesToMake = new ArrayList();
        //Point lastServerMoveMade= new Point();

        // server method to make automatic move
        // null = no more moves to make / all moves tried
        public EnumBattleGridSquare? AutoMakeMove()
        {
            Point moveToMake = AutoGenerateMove().Value;
            EnumBattleGridSquare? squareState=null;

            try
            {
                squareState = FireShot(moveToMake);

                // take out drawFiredState 

                if(squareState.HasValue)

                drawFiredState(squareState.Value== EnumBattleGridSquare.ShipHit ? true : false, moveToMake);
            }
            catch (Exception) { }

            return squareState;
        }

        public Point? AutoGenerateMove()
        {
            Point moveToMake;
            Random rnd = new Random();

            int rndNo=rnd.Next(freeServerMovesToMake.Count);

            moveToMake = (Point)freeServerMovesToMake[rndNo];
            //lastServerMovesMade.Add(moveToMake);
            freeServerMovesToMake.Remove(moveToMake);

            return moveToMake;
        }
    }
}
