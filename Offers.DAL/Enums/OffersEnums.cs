namespace Offers.DAL
{
    /// <summary>
    /// Available offer types supported by the POC
    /// </summary>
    public enum OfferTypes
    {
        Cuota = 0,
        Service = 1,
        PotentialClient = 2
    }

    /// <summary>
    /// Available offer statuses supported by the POC
    /// </summary>
    public enum OfferStatusType
    {
        PendingToValidate = 0,
        Validated = 1,
        PendingToAccept = 2,
        Accepted = 3,
        Refused = 4
    }

    /// <summary>
    /// Supported offer reasons supported by the POC
    /// </summary>
    public enum OfferReasons
    {
        FeeAdded = 0,
        ConsultationServices = 1,
        IncomeManagement = 2,
        CompleteAccounting = 3,
        Multiservice = 4
    }
}
