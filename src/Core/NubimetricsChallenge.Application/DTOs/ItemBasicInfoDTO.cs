namespace NubimetricsChallenge.Application.DTOs;

public class ItemBasicInfoDTO
{
    public string site_id { get; set; }
    public string country_default_time_zone { get; set; }
    public string query { get; set; }
    public Paging paging { get; set; }
    public List<Result> results { get; set; }
    public Sort sort { get; set; }
    public List<AvailableSort> available_sorts { get; set; }
    public List<Filter> filters { get; set; }
    public List<AvailableFilter> available_filters { get; set; }
}

public class AllowedMethod
{
    public string id { get; set; }
    public int issuer_id { get; set; }
    public string payment_type_id { get; set; }
    public object installments { get; set; }
}
public class AvailableFilter
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public List<Value> values { get; set; }
}
public class AvailableSort
{
    public string id { get; set; }
    public string name { get; set; }
}
public class Cancellations
{
    public string period { get; set; }
    public double rate { get; set; }
    public int value { get; set; }
    public Excluded excluded { get; set; }
}
public class City
{
    public string id { get; set; }
    public string name { get; set; }
}
public class Claims
{
    public string period { get; set; }
    public double rate { get; set; }
    public int value { get; set; }
    public Excluded excluded { get; set; }
}
public class Conditions
{
    public List<string> context_restrictions { get; set; }
    public DateTime? start_time { get; set; }
    public DateTime? end_time { get; set; }
    public bool eligible { get; set; }
    public List<AllowedMethod> allowed_methods { get; set; }
    public List<object> restricted_to_prices { get; set; }
}
public class Country
{
    public string id { get; set; }
    public string name { get; set; }
}
public class DelayedHandlingTime
{
    public string period { get; set; }
    public double rate { get; set; }
    public int value { get; set; }
    public Excluded excluded { get; set; }
}
public class Excluded
{
    public int real_value { get; set; }
    public int real_rate { get; set; }
}
public class Filter
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public List<Value> values { get; set; }
}
public class Metadata
{
    public string campaign_id { get; set; }
    public string promotion_id { get; set; }
    public string promotion_type { get; set; }
    public string purchase_discount_id { get; set; }
    public string purchase_discount_type { get; set; }
    public string purchase_discount_campaign_id { get; set; }
    public string purchase_discount_rebate_id { get; set; }
}
public class Metrics
{
    public Cancellations cancellations { get; set; }
    public Claims claims { get; set; }
    public DelayedHandlingTime delayed_handling_time { get; set; }
    public Sales sales { get; set; }
}
public class Paging
{
    public int total { get; set; }
    public int primary_results { get; set; }
    public int offset { get; set; }
    public int limit { get; set; }
}
public class PathFromRoot
{
    public string id { get; set; }
    public string name { get; set; }
}
public class PaymentMethodPrice
{
    public string id { get; set; }
    public Conditions conditions { get; set; }
    public int value { get; set; }
    public string type { get; set; }
    public object currency_id { get; set; }
    public Metadata metadata { get; set; }
    public string exchange_rate_context { get; set; }
}
public class Presentation
{
    public string display_currency { get; set; }
}
public class Price
{
    public string id { get; set; }
    public string type { get; set; }
    public double amount { get; set; }
    public int? regular_amount { get; set; }
    public string currency_id { get; set; }
    public DateTime last_updated { get; set; }
    public Conditions conditions { get; set; }
    public string exchange_rate_context { get; set; }
    public Metadata metadata { get; set; }
    public List<Price> prices { get; set; }
    public Presentation presentation { get; set; }
    public List<PaymentMethodPrice> payment_method_prices { get; set; }
    public List<ReferencePrice> reference_prices { get; set; }
    public List<PurchaseDiscount> purchase_discounts { get; set; }
}
public class PurchaseDiscount
{
    public string purchase_discount_id { get; set; }
    public string campaign_id { get; set; }
    public string rebate_id { get; set; }
    public string type { get; set; }
    public double discount_percentage { get; set; }
    public Conditions conditions { get; set; }
    public int purchase_min_amount { get; set; }
    public int max_discount_amount { get; set; }
    public int max_benefit_count { get; set; }
    public string funding_mode { get; set; }
}
public class Ratings
{
    public double negative { get; set; }
    public double neutral { get; set; }
    public double positive { get; set; }
}
public class ReferencePrice
{
    public string id { get; set; }
    public string type { get; set; }
    public Conditions conditions { get; set; }
    public double amount { get; set; }
    public string currency_id { get; set; }
    public string exchange_rate_context { get; set; }
    public List<object> tags { get; set; }
    public DateTime last_updated { get; set; }
}
public class Result
{
    public string id { get; set; }
    public string site_id { get; set; }
    public string title { get; set; }
    public Seller seller { get; set; }
    public double price { get; set; }
}
public class Sales
{
    public string period { get; set; }
    public int completed { get; set; }
}
public class Seller
{
    public int id { get; set; }
    public string permalink { get; set; }
}
public class Sort
{
    public string id { get; set; }
    public string name { get; set; }
}
public class Value
{
    public string id { get; set; }
    public string name { get; set; }
    public object @struct { get; set; }
    public object source { get; set; }
    public List<PathFromRoot> path_from_root { get; set; }
    public int results { get; set; }
}