using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution332 {
        private IList<string> _result;
        public IList<string> FindItinerary(IList<IList<string>> tickets) {
            //var used = new bool[tickets.Count];
            var t = Convert(tickets);
            var path = new List<string>();
            path.Add("JFK");
            Backtracking(t, path);
            return _result;
        }

        private bool Backtracking(List<Ticket> tickets, List<string> path) {
            if (path.Count == tickets.Count + 1) {
                _result = path;
                return true;
            }

            var start = path.Last();

            for (var i = 0; i < tickets.Count; ++i) {
                var ticket = tickets[i];
                if (ticket.From != start || ticket.Used) {
                    continue;
                }

                path.Add(ticket.To);
                ticket.Used = true;
                if (Backtracking(tickets, path)) {
                    return true;
                }
                ticket.Used = false;
                path.RemoveAt(path.Count - 1);
            }
            return false;
        }

        private List<Ticket> Convert(IList<IList<string>> ticketInfo) {
            var tickets = new List<Ticket>();
            foreach (var ticket in ticketInfo) {
                tickets.Add(new Ticket() {
                    From = ticket[0],
                    To = ticket[1],
                    Used = false,
                });
            }

            // Sort tickets here so that the ticket can be searched by alphabetic order
            tickets = tickets.OrderBy(tt => tt.From).ThenBy(tt => tt.To).ToList();
            return tickets;
        }
    }

    public class Ticket {
        public String From { get; set; }
        public String To { get; set; }
        public Boolean Used { get; set; }
    }
}