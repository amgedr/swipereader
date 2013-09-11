using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SwipeReader
{
    class Networking
    {
        /// <summary>
        /// Pings a host to find out if it is reachable.
        /// </summary>
        /// <param name="host">The IP address of name of the host.</param>
        /// <param name="echoRequest">The number of times to send the echo requests.</param>
        /// <returns>True if reachable. False otherwise.</returns>
        public static bool Ping(string host, int echoRequest = 1)
        {
            try
            {
                for (int i = 0; i < echoRequest; i++)
                {
                    System.Net.NetworkInformation.Ping ping =
                        new System.Net.NetworkInformation.Ping();

                    System.Net.NetworkInformation.PingReply pingReply = ping.Send(host);
                }

                return true;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}