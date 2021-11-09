using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WFang.EventSystem
{
    public struct EventMessage
    {
        /// <summary>
        /// 이벤트 ID
        /// </summary>
        public readonly int eventId;

        /// <summary>
        /// 보내는 객체의 key
        /// </summary>
        public readonly string senderKey;

        /// <summary>
        /// 받는 객체의 key
        /// </summary>
        public readonly string receiverKey;

        /// <summary>
        /// 이벤트 발생 시간
        /// </summary>
        public readonly DateTime eventTime;
        /// <summary>
        /// 이벤트 지연 전달 시간.
        /// ex) DateTime.Now >= eventTime + delayTime
        /// </summary>
        public readonly TimeSpan delayTime;

        public readonly object[] param;

        public EventMessage( int eventId, string senderKey, string receiverKey, DateTime eventTime, TimeSpan delayTime, params object[] param)
        {
            this.eventId = eventId;
            this.senderKey = senderKey;
            this.receiverKey = receiverKey;
            this.eventTime = eventTime;
            this.delayTime = delayTime;
            this.param = param;
        }

        /// <summary>
        /// 지연 시간 도달?
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return DateTime.Now >= eventTime + delayTime;
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize( this, new JsonSerializerOptions() { WriteIndented = true } );
        }
    }
}

