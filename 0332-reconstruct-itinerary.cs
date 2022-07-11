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

        private static List<Ticket> Convert(IList<IList<string>> ticketInfo) {
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
        public string From { get; set; }
        public string To { get; set; }
        public bool Used { get; set; }
    }

    ///This solution uses a new structure to keep the mappings between source city and target city    
    public class Solution332New {
        private readonly Dictionary<string, ItemCountDictionary<string>> _maps = new();
        private readonly IList<string> _result = new List<string>();

        public IList<string> FindItinerary(IList<IList<string>> tickets) {
            _maps.Clear();

            foreach (var pair in tickets) {
                var source = pair[0];
                var target = pair[1];

                if (!_maps.ContainsKey(source)) {
                    _maps.Add(source, new ItemCountDictionary<string>());
                }
                _maps[source][target]++;
            }

            _result.Clear();
            _result.Add("JFK");
            BackTracking(tickets.Count);
            return _result;
        }

        private bool BackTracking(int ticketNumber) {
            if (_result.Count == ticketNumber + 1) {
                return true;
            }

            var source = _result.ElementAt(_result.Count - 1);
            if (!_maps.ContainsKey(source)) {
                return false;
            }

            foreach (var targetCount in _maps[source].OrderBy(t => t.Key)) {
                if (targetCount.Value == 0) {
                    continue;
                }

                _maps[source][targetCount.Key]--;
                _result.Add(targetCount.Key);
                if (BackTracking(ticketNumber)) {
                    return true;
                }
                _result.RemoveAt(_result.Count - 1);
                _maps[source][targetCount.Key]++;
            }
            return false;
        }
    }
}