namespace Adapter.ThirdParty.QuickPay
{
    // Simulates a legacy third-party API: we can't change this code.
    // It exchanges plain strings, e.g. "AMOUNT=49.90;CUR=EUR" -> "OK|QP-1001" or "KO|<reason>".
    public class QuickPayApi
    {
        private int _nextReference = 1001;

        public string Submit(string payload)
        {
            var fields = payload
                .Split(';')
                .Select(field => field.Split('='))
                .ToDictionary(pair => pair[0], pair => pair[1]);

            if (fields["CUR"] != "EUR")
                return "KO|Currency not supported";

            return $"OK|QP-{_nextReference++}";
        }
    }
}
