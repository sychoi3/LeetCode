using System.Collections.Generic;
using System.Linq;

namespace Playground {
    // GOOGLE INTERVIEW QUESTION: given array of arrival_times, array of duration, and a roomCount, find the room number used most.
    // rooms are selected by priorty if room 1 & 2 is available, must select room 1.
    
    public class Solution {

        /*
            arrival_times:  [1,3,6,9,11]
            durations:      [20,1,2,5,4]
            rooms:          3

            start:           1, 3, 6, 9, 11
            end:            21, 4, 8,14, 15

            availableRooms: 3
            usedRooms:      21:1, 14:2, 
            room_usage:     [1,3,0]     
        */
        public int solve(int[] arrival_times, int[] durations, int rooms){
            
            var rooms_usage = new int[rooms];
            var availableRooms = new SortedDictionary<int,int>();
            for(int i = 0;i<rooms;i++) availableRooms.Add(i,i);

            var usedRooms = new SortedDictionary<int,int>();    // endTime:roomNumber

            for(int i = 0;i<arrival_times.Length;i++){
                var start = arrival_times[i];
                var end = start+durations[i];

                foreach(var used in usedRooms){
                    if(start > used.Key){
                        availableRooms.Add(used.Value, used.Value);
                        usedRooms.Remove(used.Key);
                    }
                }

                var availableRoom = availableRooms.First();
                availableRooms.Remove(availableRoom.Key);   // dequeue

                rooms_usage[availableRoom.Key]++;
                usedRooms.Add(end, availableRoom.Key);
            }
            
            // find room used most.
            var maxUsedRoom = 0;
            for(int i = 0;i<rooms_usage.Length;i++){
                if(rooms_usage[i] >rooms_usage[maxUsedRoom])
                    maxUsedRoom = i;
            }
            return maxUsedRoom;
        }
    }
}