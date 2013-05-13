using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace game_v0._1 
{
    /// <summary>
    /// this is a base class
    /// </summary>
    class thingy
    {
        #region //------------------basic variables------------------\\

        private Texture2D skin;
        public Texture2D Skin
        {
            get
            {
                return skin;
            }
            set
            {
                skin = value;
            }
        }

        private floatRectangle shape;
        public floatRectangle Shape
        {
            get
            {
                return shape;
            }
            set
            {
                shape = value;
            }
        }

        private float rotation;
        public float Rotation
        {
            get
            {
                if(Math.Abs(rotation % (float)2*(Math.PI)) == 0)
                {
                    rotation = 0;
                }
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        private float speed;
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        private Vector2 destination;
        public Vector2 Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Rectangle boundingBox
        {
            get
            {
                float minX = topLeft.X;
                float maxX = topRight.X;
                float minY = bottomLeft.Y;
                float maxY = bottomRight.Y;

                #region find minX
                if (minX > topRight.X)
                {
                    minX = topRight.X;
                }
                if (minX > bottomLeft.X)
                {
                    minX = bottomLeft.X;
                }
                if (minX > bottomRight.X)
                {
                    minX = bottomRight.X;
                }
                #endregion

                #region find maxX
                if (maxX < topLeft.X)
                {
                    maxX = topLeft.X;
                }
                if (maxX < bottomLeft.X)
                {
                    maxX = bottomLeft.X;
                }
                if (maxX < bottomRight.X)
                {
                    maxX = bottomRight.X;
                }
                #endregion

                #region find minY
                if (minY > topLeft.Y)
                {
                    minY = topLeft.Y;
                }
                if (minY > topRight.Y)
                {
                    minY = topRight.Y;
                }
                if (minY > bottomRight.Y)
                {
                    minY = bottomRight.Y;
                }
                #endregion

                #region find maxY
                if (maxY < topLeft.Y)
                {
                    maxY = topLeft.Y;
                }
                if (maxY < topRight.Y)
                {
                    maxY = topRight.Y;
                }
                if (maxY < bottomLeft.Y)
                {
                    maxY = bottomLeft.Y;
                }
                #endregion

                return new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));

            }
        }

        public Vector2 center
        {
            get
            {
                return new Vector2((topLeft.X + bottomRight.X) / 2, (topLeft.Y + bottomRight.Y) / 2);
            }
        }

        public Vector2 topRight
        {
            get
            {
                Vector2 toReturn = new Vector2(topLeft.X, topLeft.Y);
                toReturn.X += (float)(Math.Cos(rotation) * shape.Width);
                toReturn.Y += (float)(Math.Sin(rotation) * shape.Width);
                return toReturn;
            }
        }

        public Vector2 bottomLeft
        {
            get
            {
                Vector2 toReturn = new Vector2(topLeft.X, topLeft.Y);
                toReturn.X -= (float)(Math.Cos(rotation - Math.PI / 2) * shape.Height);
                toReturn.Y -= (float)(Math.Sin(rotation - Math.PI / 2) * shape.Height);
                return toReturn;
            }
        }

        public Vector2 bottomRight
        {
            get
            {
                Vector2 temp = bottomLeft;
                Vector2 toReturn = new Vector2(temp.X, temp.Y);
                toReturn.X += (float)(Math.Cos(rotation) * shape.Width);
                toReturn.Y += (float)(Math.Sin(rotation) * shape.Width);
                return toReturn;
            }
        }

        public Vector2 topLeft
        {
            get
            {
                return new Vector2(shape.X, shape.Y);
            }
        }

        private Keys up = Keys.W;
        public Keys Up
        {
            get
            {
                return up;
            }
            set
            {
                up = value;
            }
        }

        private Keys down = Keys.S;
        public Keys Down
        {
            get
            {
                return down;
            }
            set
            {
                down = value;
            }
        }

        private Keys left = Keys.A;
        public Keys Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        private Keys right = Keys.D;
        public Keys Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
        #endregion
        
        #region //-----------------constructors-----------------------\\

        /// <summary>
        /// Creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        /// <param name="rect">the shape of the thingy</param>
        /// <param name="rot">the rotation of the thingy</param>
        /// <param name="spe">the speed of the thingy</param>
        public thingy(Texture2D ski, Rectangle rect, float rot, float spe)
        {
            skin = ski;
            shape = new floatRectangle(rect);
            rotation = rot;
            speed = spe;
            setDefaults();
        }

        /// <summary>
        /// creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        public thingy(Texture2D ski)
        {
            skin = ski;
            shape = new floatRectangle(new Rectangle());
            rotation = 0f;
            speed = 0f;
            setDefaults();
        }

        /// <summary>
        /// creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        /// <param name="rect">the shape of the thingy</param>
        public thingy(Texture2D ski, Rectangle rect)
        {
            skin = ski;
            shape = new floatRectangle(rect);
            rotation = 0f;
            speed = 0f;
            setDefaults();
        }

        /// <summary>
        /// called in all constructors to set the default values of various variables
        /// </summary>
        private void setDefaults()
        {
            destination = center;
            color = newRandomColor();
            isAlive = true;
            isCollidable = true;
            moveWithKeys = false;
            orientOnDestination = false;
            orientOnMouse = false;
            moveForever = false;
            backOffAuto = false;
            moveWithGamePad = false;
            getClose = -1;
        }
        #endregion

        #region //-----------function toggle variables-----------------\\

        /// <summary>
        /// shouldn't be deleted
        /// </summary>
        public bool isAlive;
        /// <summary>
        /// will collide with thingys
        /// </summary>
        public bool isCollidable;
        /// <summary>
        /// will move when the proper key is pressed
        /// </summary>
        public bool moveWithKeys;
        /// <summary>
        /// turns to face destination always
        /// </summary>
        public bool orientOnDestination;
        /// <summary>
        /// turns to face mouse always
        /// </summary>
        public bool orientOnMouse;
        /// <summary>
        /// will keep moving beyond destination, off the screen, then flag itself as dead. Locks the destination in place if true
        /// </summary>
        public bool moveForever;
        /// <summary>
        /// if true, will automatically back off an overlap
        /// </summary>
        public bool backOffAuto;
        /// <summary>
        /// if true, will move with the gamepad that matches it's player number
        /// </summary>
        public bool moveWithGamePad;
        /// <summary>
        /// -1 for false, else, how close to get to destination
        /// </summary>
        public float getClose;
    

        #endregion

        #region //---------------------methods--------------------------\\

        /// <summary>
        /// updates the thingys location
        /// </summary>
        public void move()
        {

            if (orientOnDestination)
            {
                rotation = (float)(Math.Atan2(destination.Y - shape.Y , destination.X - shape.X ) + Math.PI / 2);
            }

            if (orientOnMouse)
            {
               MouseState mouse = Mouse.GetState();
               rotation = (float)(Math.Atan2((shape.Y - mouse.Y), (shape.X - mouse.X)) + Math.PI / 2);
            }

            if (moveWithGamePad)
            {
                orientOnDestination = false;
                orientOnMouse = false;
                if (this is player)
                {
                    player temp = (player)this;
                    if(temp.PlayerNum > 0 && temp.PlayerNum <=4)
                    {
                        PlayerIndex num = PlayerIndex.One;

                        if(temp.PlayerNum == 2)
                        {
                            num = PlayerIndex.Two;
                        }
                        if(temp.PlayerNum == 3)
                        {
                            num = PlayerIndex.Three;
                        }
                        if(temp.PlayerNum == 4)
                        {
                            num = PlayerIndex.Four;
                        }

                        shape.X += GamePad.GetState(num).ThumbSticks.Left.X * speed;
                        shape.Y -= GamePad.GetState(num).ThumbSticks.Left.Y * speed;
                        Vector2 rotPoint = new Vector2(GamePad.GetState(num).ThumbSticks.Right.X, GamePad.GetState(num).ThumbSticks.Right.Y);
                        if (GamePad.GetState(num).ThumbSticks.Right.X != 0 && GamePad.GetState(num).ThumbSticks.Right.Y != 0)
                        {
                            rotation = (float)Math.Atan2(-rotPoint.Y, rotPoint.X);
                            rotation -= (float)Math.PI / 2;
                        }

                    }
                }

                

            }
            else
            {
                if (moveWithKeys)
                {
                    KeyboardState keyboard = Keyboard.GetState();
                    if (keyboard.IsKeyDown(right))
                    {
                        shape.X += speed;//change shape to destination
                    }
                    if (keyboard.IsKeyDown(left))
                    {
                        shape.X -= speed;//change shape to destination
                    }
                    if (keyboard.IsKeyDown(up))
                    {
                        shape.Y -= speed;//change shape to destination
                    }
                    if (keyboard.IsKeyDown(down))
                    {
                        shape.Y += speed;//change shape to destination
                    }
                    destination.X = shape.X;  //comment out
                    destination.Y = shape.Y;  //comment out
                }

                if (moveForever)
                {
                    if (Math.Abs(distance(topLeft, destination)) < speed * 2)
                    {
                        setDesAhead();
                    }
                }

                if (topLeft != destination)
                {
                    float theata = (float)(Math.Atan2(Math.Abs(shape.Y - destination.Y), Math.Abs(shape.X - destination.X)));
                    float newX = (float)(speed * Math.Cos(theata));
                    float newY = (float)(speed * Math.Sin(theata));

                    if (shape.X > destination.X)
                    {
                        shape.X -= newX;
                    }
                    else
                    {
                        shape.X += newX;
                    }

                    if (shape.Y > destination.Y)
                    {
                        shape.Y -= newY;
                    }
                    else
                    {
                        shape.Y += newY;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if two thingys are touching
        /// </summary>
        /// <param name="other">the thingy to compare against</param>
        /// <returns>true if touching, else false</returns>
        public bool intercepts(thingy other)
        {
            bool toReturn = false;
            bool sameGuy = this.Shape == other.Shape && this.Rotation == other.Rotation;//makes sure that both thingys aren't the same thingy
            if (this.isCollidable && other.isCollidable && !sameGuy)
            {
                if (this.boundingBox.Intersects(other.boundingBox))
                {
                    if (this.containsPoint(other.topLeft)
                    || this.containsPoint(other.topRight)
                    || this.containsPoint(other.bottomLeft)
                    || this.containsPoint(other.bottomRight)
                    || other.containsPoint(this.topLeft)
                    || other.containsPoint(this.topRight)
                    || other.containsPoint(this.bottomLeft)
                    || other.containsPoint(this.bottomRight))
                    {
                        toReturn = true;
                    }
                    else
                    {
                        toReturn = this.linesIntersect(other);
                    }
                }
            }
            return toReturn;
        }


        /// <summary>
        /// draws the thingy
        /// </summary>
        /// <param name="batch">the spritebatch to draw this thingy</param>
        public virtual void draw(SpriteBatch batch)
        {
            batch.Draw(
                skin,
                shape.roundedRectangle,
                null,
                color,
                rotation,
                new Vector2(0, 0),
                SpriteEffects.None,
                0);
        }

        /// <summary>
        /// this sets an objects destination ahead of it 3X it's speed at an angle of its rotation
        /// </summary>
        public void setDesAhead()
        {
            float z = speed * 10000;

            float changeY = (float)Math.Sin(rotation) * z;
            float changeX = (float)Math.Cos(rotation) * z;

            destination.Y = shape.Y + changeY;
            destination.X = shape.X + changeX;
        }

        /// <summary>
        /// Move up to an interception. Should be overwritten by subclasses
        /// </summary>
        public virtual void update(ref List<thingy> thingys)
        {
            
            bool hasCollided = false;
            float oldSpeed = speed;
            speed = speed / 3;
         
            float count = 0;
            bool closeEnough = false;
            if (getClose != -1)
            {
                bool safeX = Math.Abs(topLeft.X - destination.X) <= getClose;
                bool safeY = Math.Abs(topLeft.Y - destination.Y) <= getClose;
                if (safeY && safeX && !moveWithGamePad && !moveWithKeys)
                {

                    closeEnough = true;
                }
            }
            while(count < oldSpeed && !hasCollided && !closeEnough)
            {
                foreach (thingy thingy in thingys)
                {
                        if(this.intercepts(thingy))
                        {
                            hasCollided = true;
                        }
                    
                }
                this.move();
                
                count += oldSpeed / 3;

                if (getClose != -1)
                {
                    bool safeX = Math.Abs(topLeft.X - destination.X) <= getClose;
                    bool safeY = Math.Abs(topLeft.Y - destination.Y) <= getClose;
                    if (safeY && safeX && !moveWithGamePad && !moveWithKeys)
                    {

                        closeEnough = false;
                    }
                }

            }
            speed = oldSpeed;


            if (backOffAuto)
            {
                backOffOverlap(ref thingys);
            }
        }

        /// <summary>
        /// moves a thingy backwards until it doesn't overlap any thingys
        /// </summary>
        /// <param name="thingys"></param>
        public void backOffOverlap(ref List<thingy> thingys)
        {
            float oldSpeed = this.Speed;
            bool intercepts = true;
            while (intercepts)
            {
                foreach (thingy thingy in thingys)
                {
                    while (this.intercepts(thingy))
                    {
                        this.speed = -1;
                        this.move();
                    }
                    this.speed = oldSpeed;
                }
                intercepts = false;
                foreach (thingy thingy in thingys)
                {
                    if (thingy.intercepts(thingy))
                    {
                        intercepts = true;
                    }
                }
            }
        }

        #endregion

        #region//------------------helper methods-----------------------\\

        /// <summary>
        /// used by intercepts to checks if a Vector2 is in a thingy
        /// </summary>
        /// <param name="point">the Vector2 to check</param>
        /// <returns>true if contains point, else false</returns>
        public bool containsPoint(Vector2 point)
        {
            bool toReturn = false;
            thingy box = this;
            bool xGood = false;
            bool yGood = false;
            double undoAngle = Math.Atan2(box.topRight.Y - box.topLeft.Y, box.topRight.X - box.topLeft.X);
            double curAngle = Math.Atan2(box.topRight.Y - point.Y, box.topRight.X - point.X);
            double newAngle = curAngle - undoAngle;
            double disToPoint = (box.topRight.Y - point.Y) / Math.Sin(curAngle);
            float changeX = (float)(Math.Sin(newAngle + Math.PI / 2) * disToPoint);
            float changeY = (float)(Math.Cos(newAngle + Math.PI / 2) * disToPoint);
            Vector2 unRotatePoint = new Vector2(box.topLeft.X + changeX, box.topLeft.Y + changeY);
            if (box.shape.X <= unRotatePoint.X && unRotatePoint.X <= box.shape.Width + box.shape.X)
            {
                xGood = true;
            }
            if (box.shape.Y <= unRotatePoint.Y && unRotatePoint.Y <= box.shape.Height + box.shape.Y)
            {
                yGood = true;
            }
            if (xGood && yGood)
            {
                toReturn = true;
            }
            return toReturn;
        }

        /// <summary>
        /// this goes through all the edges of the two thingys and checks if they collide
        /// </summary>
        /// <param name="other">the second thingy</param>
        /// <returns>true if they cross, else false</returns>
        private bool linesIntersect(thingy other)
        {
            bool toReturn = false;

            Vector4 thisOne = new Vector4(this.topRight.X, this.topRight.Y, this.topLeft.X, this.topLeft.Y);//a line between topright and topleft
            Vector4 thisTwo = new Vector4(this.topRight.X, this.topRight.Y, this.bottomRight.X, this.bottomRight.Y);
            Vector4 thisThree = new Vector4(this.bottomRight.X, this.bottomRight.Y, this.bottomLeft.X, this.bottomLeft.Y);
            Vector4 thisFour = new Vector4(this.topLeft.X, this.topLeft.Y, this.bottomLeft.X, this.bottomLeft.Y);

            Vector4 otherOne = new Vector4(other.topRight.X, other.topRight.Y, other.topLeft.X, other.topLeft.Y);//a line between topright and topleft
            Vector4 otherTwo = new Vector4(other.topRight.X, other.topRight.Y, other.bottomRight.X, other.bottomRight.Y);
            Vector4 otherThree = new Vector4(other.bottomRight.X, other.bottomRight.Y, other.bottomLeft.X, other.bottomLeft.Y);
            Vector4 otherFour = new Vector4(other.topLeft.X, other.topLeft.Y, other.bottomLeft.X, other.bottomLeft.Y);

            if (lineIntersection(thisOne, otherOne)
                || lineIntersection(thisOne, otherTwo)
                || lineIntersection(thisOne, otherThree)
                || lineIntersection(thisOne, otherFour))
            {
                toReturn = true;
            }
            else
            {
                if (lineIntersection(thisTwo, otherOne)
                || lineIntersection(thisTwo, otherTwo)
                || lineIntersection(thisTwo, otherThree)
                || lineIntersection(thisTwo, otherFour))
                {
                    toReturn = true;
                }
                else
                {
                    if (lineIntersection(thisThree, otherOne)
                    || lineIntersection(thisThree, otherTwo)
                    || lineIntersection(thisThree, otherThree)
                    || lineIntersection(thisThree, otherFour))
                    {
                        toReturn = true;
                    }
                    else
                    {
                        if (lineIntersection(thisFour, otherOne)
                        || lineIntersection(thisFour, otherTwo)
                        || lineIntersection(thisFour, otherThree)
                        || lineIntersection(thisFour, otherFour))
                        {
                            toReturn = true;
                        }
                    }
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Checks if two lines cross
        /// </summary>
        /// <param name="lineA">the first line</param>
        /// <param name="lineB">the second line</param>
        /// <returns>true if they do cross</returns>
        private bool lineIntersection(Vector4 lineA, Vector4 lineB)
        {
            bool toReturn = false;

            Vector2 toCheckContainedPoint = new Vector2();
            Vector2 thisOne = new Vector2(lineA.X, lineA.Y);
            Vector2 thisTwo = new Vector2(lineA.Z, lineA.W);


            Vector2 otherOne = new Vector2(lineB.X, lineB.Y);
            Vector2 otherTwo = new Vector2(lineB.Z, lineB.W);

            float thisSlope = 0;
            float otherSlope = 0;

            float rot = 0.0f;
            while (thisOne.X == thisTwo.X || thisOne.Y == thisTwo.Y || otherOne.Y == otherTwo.Y || otherOne.X == otherTwo.X)
            {
                rot += 0.1f;
                thisOne = rotatePointAboutOrgin(thisOne, rot);
                thisTwo = rotatePointAboutOrgin(thisTwo, rot);

                otherOne = rotatePointAboutOrgin(otherOne, rot);
                otherTwo = rotatePointAboutOrgin(otherTwo, rot);

            }
            thisSlope = (thisOne.Y - thisTwo.Y) / (thisOne.X - thisTwo.X);
            otherSlope = (otherOne.Y - otherTwo.Y) / (otherOne.X - otherTwo.X);
            float thisInter = -(thisSlope * thisOne.X) + thisOne.Y;
            float otherInter = -(otherSlope * otherOne.X) + otherOne.Y;
            if (thisSlope != otherSlope)
            {
                toCheckContainedPoint.X = (otherInter - thisInter) / (thisSlope - otherSlope);
                toCheckContainedPoint.Y = thisSlope * toCheckContainedPoint.X + thisInter;



                if (isBetween(otherOne, toCheckContainedPoint, otherTwo) && isBetween(thisOne, toCheckContainedPoint, thisTwo))
                {
                    toReturn = true;
                }

            }
            else
            {
                if (thisInter == otherInter)
                {
                    if (isBetween(thisOne, otherOne, thisTwo) || isBetween(thisOne, otherTwo, thisTwo)
                        || isBetween(otherOne, thisOne, otherTwo) || isBetween(otherOne, thisTwo, otherTwo))
                        toReturn = true;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// rotates a point around the orgin
        /// </summary>
        /// <param name="point">the point</param>
        /// <param name="rot">the rotation</param>
        /// <returns>a new point that is rotated</returns>
        private Vector2 rotatePointAboutOrgin(Vector2 point, float rot)
        {
            Vector2 toReturn = point;
            double curAngle = Math.Atan2(-point.Y, -point.X);
            double newAngle = curAngle + rot;
            double disToPoint = (-point.Y) / Math.Sin(curAngle);
            float changeX = (float)(Math.Sin(newAngle + Math.PI / 2) * disToPoint);
            float changeY = (float)(Math.Cos(newAngle + Math.PI / 2) * disToPoint);
            toReturn = new Vector2(changeX, changeY);
            return toReturn;
        }

        /// <summary>
        /// Checks if one point is between two others
        /// </summary>
        /// <param name="one">the first point</param>
        /// <param name="betwix">the middle point</param>
        /// <param name="two">the second point</param>
        /// <returns>true if betwix is between one and two</returns>
        private bool isBetween(Vector2 one, Vector2 betwix, Vector2 two)
        {
            bool toReturn = false;

            bool a = ((one.X <= betwix.X && betwix.X <= two.X) || (one.X >= betwix.X && betwix.X >= two.X));
            bool b = ((one.Y <= betwix.Y && betwix.Y <= two.Y) || (one.Y >= betwix.Y && betwix.Y >= two.Y));

            if (a && b)
            {
                toReturn = true;
            }
            return toReturn;
        }

        /// <summary>
        /// generates a random color
        /// </summary>
        /// <returns>a random color</returns>
        private Color newRandomColor()
        {
            float minAccColor = 0.5f;
            Random rand = new Random();
            float red = (float)rand.NextDouble();
            float green =(float)rand.NextDouble();
                float blue = (float)rand.NextDouble();
                    float alpha = (float)rand.NextDouble();
            bool tooLight = true;
            while (tooLight)
            {
                 red = (float)rand.NextDouble();
                 green = (float)rand.NextDouble();
                 blue = (float)rand.NextDouble();
                 alpha = (float)rand.NextDouble();
                if (red > minAccColor && green > minAccColor && blue > minAccColor && alpha > minAccColor)
                {
                    tooLight = false;
                }
            }
            return new Color(red, green, blue, alpha);
        }

        /// <summary>
        /// finds the distance between two points
        /// </summary>
        /// <param name="one">first point</param>
        /// <param name="two">second point</param>
        /// <returns>distance between both points</returns>
        private float distance(Vector2 one, Vector2 two)
        {
            float a = (float)(Math.Pow(two.X - one.X, 2));
            float b = (float)(Math.Pow(two.Y - one.Y, 2));
            return (float)(Math.Sqrt(a + b));
        }
        #endregion
    }
}