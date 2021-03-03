using KinectXEFTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;


namespace Extractor
{
    class XEFBodyWriter : IXEFDataWriter, IDisposable
    {
        //
        //  Members
        //

        private StreamWriter _writer;

        private bool _seenEvent = false;

        //
        //  Properties
        //

        public string FilePath { get; private set; }

        public long EventCount { get; private set; }

        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public TimeSpan Duration { get { return EndTime - StartTime; } }

        //
        //  Constructor
        //

        public XEFBodyWriter(string path)
        {
            FilePath = path;
            EventCount = 0;
            StartTime = TimeSpan.Zero;
            EndTime = TimeSpan.Zero;

            _writer = new StreamWriter(path);

            WriteHeaders();
        }

        ~XEFBodyWriter()
        {
            Dispose(false);
        }

        //
        //	IDisposable
        //

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _writer.Dispose();
                }

                disposed = true;
            }
        }
        /// <summary>
        /// 定义链接MySQL
        /// </summary>
        /// 
        //private void MyConnector()
        //{
        //    string myServer = "server = localhost; port = 3306; User ID = root; password = winter; database = skeleton";
        //    string newTable = "CREATE TABLE depression (DepressionID VarChar(50), EventIndex Integer)";
        //    MySqlConnection myConnection = new MySqlConnection(myServer);
        //    myConnection.Open();
        //    Console.WriteLine("Connected!");
        //    using (MySqlCommand createTablel = new MySqlCommand(newTable, myConnection))
        //    {
        //        createTablel.ExecuteNonQuery();
        //        Console.WriteLine("New table created!");
        //    }
        //}
        private void WriteHeaders()
        {
            ///
            ///保存所有的骨架节点信息
            ///
            _writer.WriteLine("EventIndex,Time,SkeletonId,SpineBasePositionX,SpineBasePositionY,SpineBasePositionZ,SpineBaseRotationW,SpineBaseRotationX,SpineBaseRotationY,SpineBaseRotationZ,SpineMidPositionX,SpineMidPositionY,SpineMidPositionZ,SpineMidRotationW,SpineMidRotationX,SpineMidRotationY,SpineMidRotationZ,NeckPositionX,NeckPositionY,NeckPositionZ,NeckRotationW,NeckRotationX,NeckRotationY,NeckRotationZ,HeadPositionX,HeadPositionY,HeadPositionZ,HeadRotationW,HeadRotationX,HeadRotationY,HeadRotationZ,ShoulderLeftPositionX,ShoulderLeftPositionY,ShoulderLeftPositionZ,ShoulderLeftRotationW,ShoulderLeftRotationX,ShoulderLeftRotationY,ShoulderLeftRotationZ,ElbowLeftPositionX,ElbowLeftPositionY,ElbowLeftPositionZ,ElbowLeftRotationW,ElbowLeftRotationX,ElbowLeftRotationY,ElbowLeftRotationZ,WristLeftPositionX,WristLeftPositionY,WristLeftPositionZ,WristLeftRotationW,WristLeftRotationX,WristLeftRotationY,WristLeftRotationZ,HandLeftPositionX,HandLeftPositionY,HandLeftPositionZ,HandLeftRotationW,HandLeftRotationX,HandLeftRotationY,HandLeftRotationZ,ShoulderRightPositionX,ShoulderRightPositionY,ShoulderRightPositionZ,ShoulderRightRotationW,ShoulderRightRotationX,ShoulderRightRotationY,ShoulderRightRotationZ,ElbowRightPositionX,ElbowRightPositionY,ElbowRightPositionZ,ElbowRightRotationW,ElbowRightRotationX,ElbowRightRotationY,ElbowRightRotationZ,WristRightPositionX,WristRightPositionY,WristRightPositionZ,WristRightRotationW,WristRightRotationX,WristRightRotationY,WristRightRotationZ,HandRightJoint,HandRightPositionY,HandRightPositionZ,HandRightRotationW,HandRightRotationX,HandRightRotationY,HandRightRotationZ,HipLeftPositionX,HipLeftPositionY,HipLeftPositionZ,HipLeftRotationW,HipLeftRotationX,HipLeftRotationY,HipLeftRotationZ,KneeLeftPositionX,KneeLeftPositionY,KneeLeftPositionZ,KneeLeftRotationW,KneeLeftRotationX,KneeLeftRotationY,KneeLeftRotationZ,AnkleLeftPositionX,AnkleLeftPositionY,AnkleLeftPositionZ,AnkleLeftRotationW,AnkleLeftRotationX,AnkleLeftRotationY,AnkleLeftRotationZ,FootLeftPositionX,FootLeftPositionY,FootLeftPositionZ,FootLeftRotationW,FootLeftRotationX,FootLeftRotationY,FootLeftRotationZ,HipRightPositionX,HipRightPositionY,HipRightPositionZ,HipRightRotationW,HipRightRotationX,HipRightRotationY,HipRightRotationZ,KneeRightPositionX,KneeRightPositionY,KneeRightPositionZ,KneeRightRotationW,KneeRightRotationX,KneeRightRotationY,KneeRightRotationZ,AnkleRightPositionX,AnkleRightPositionY,AnkleRightPositionZ,AnkleRightRotationW,AnkleRightRotationX,AnkleRightRotationY,AnkleRightRotationZ,FootRightPositionX,FootRightPositionY,FootRightPositionZ,FootRightRotationW,FootRightRotationX,FootRightRotationY,FootRightRotationZ,SpineShoulderPositionX,SpineShoulderPositionY,SpineShoulderPositionZ,SpineShoulderRotationW,SpineShoulderRotationX,SpineShoulderRotationY,SpineShoulderRotationZ,HandTipLeftPositionX,HandTipLeftPositionY,HandTipLeftPositionZ,HandTipLeftRotationW,HandTipLeftRotationX,HandTipLeftRotationYHandTipLeft,HandTipLeftRotationZ,ThumbLeftPositionX,ThumbLeftPositionY,ThumbLeftPositionZ,ThumbLeftRotationW,ThumbLeftRotationX,ThumbLeftRotationYThumbLeft,ThumbLeftRotationZ,HandTipRightPositionX,HandTipRightPositionY,HandTipRightPositionZ,HandTipRightRotationW,HandTipRightRotationX,HandTipRightRotationY,HandTipRightRotationZ,ThumbRightPositionX,ThumbRightPositionY,ThumbRightPositionZ,ThumbRightRotationW,ThumbRightRotationX,ThumbRightRotationY,ThumbRightRotationZ");
        }

        public void Close()
        {
            Dispose(true);
        }
        // private TimeSpan _frameDuration;
        /// <summary>
        /// 基于帧的骨架信息提取
        /// </summary>
        /// <param name="ev"></param>
        ///
        public void ProcessEvent(XEFEvent ev)
        {
            if (ev.EventStreamDataTypeId != StreamDataTypeIds.Body)
            {
                return;
            }

            // Update start/end time
            if (!_seenEvent)
            {
                StartTime = ev.RelativeTime;
                _seenEvent = true;
            }
            EndTime = ev.RelativeTime;

            // Get raw body data
            //Redefined the tracked information
            //只抓取主要的被测人员的信息
            XEFBodyFrame bodyFrame = XEFBodyFrame.FromByteArray(ev.EventData);

            for (int i = 0; i < bodyFrame.BodyData.Length; i++)
            {
                XEFBodyData body = bodyFrame.BodyData[i];
                if (body.TrackingState == XEFBodyTrackingState.TRACKED)
                {
                    // Write skeleton body
                    _writer.Write("{0},{1},{2}",
                        ev.EventIndex,
                        ev.RelativeTime.Ticks,
                        body.TrackingID);

                    //_writer.Write(",{0},{1}",
                    //    body.HandDataLeft.HandConfidence,
                    //    body.HandDataLeft.HandState);

                    //_writer.Write(",{0},{1}",
                    //    body.HandDataRight.HandConfidence,
                    //    body.HandDataRight.HandState);

                    // Enumerate all joints
                    foreach (XEFJointType jointType in Enum.GetValues(typeof(XEFJointType)))
                    {
                        // Write skeleton joint
                        XEFTrackingState jointTrackingState = body.SkeletonJointPositionTrackingStates[jointType];
                        XEFVector jointPosition = body.SkeletonJointPositions[jointType];
                        XEFVector jointOrientation = body.SkeletonJointOrientations[jointType];

                        _writer.Write(",{0},{1},{2}",
                            jointPosition.x,
                            jointPosition.y,
                            jointPosition.z);

                        _writer.Write(",{0},{1},{2},{3}",
                            jointOrientation.w,
                            jointOrientation.x,
                            jointOrientation.y,
                            jointOrientation.z);
                    }
                    _writer.WriteLine();
                }
            }
            EventCount++;
        }
    }
}
