using System;
using System.Collections.Generic;
using PowerServer.ServerAil;
using System.Text;

namespace PublisherServer
{
    public class PubliserServer
    {
        private Dictionary<int, IModules.ITopicNode> _topics;
        private PubliserServer()
        {
            _topics = new Dictionary<int, IModules.ITopicNode>();
        }
        static PubliserServer ins = new PubliserServer();
        public static PubliserServer GetInstance()
        {
            return ins;
        }

        public bool pushRTInfo()
        {
            foreach (var item in _topics)
            {
                item.Value.getPublisherEvents().pushRTInfo(item.Value.getTopicInfo().getClientInfo());
            }
            return false;
        }

        public bool pushADInfo()
        {
            return false;
        }

        public bool addTopicNode(int id,IModules.ITopicNode topicnode)
        {
            _topics.Add(id, topicnode);
            return false;
        }
    }
}
