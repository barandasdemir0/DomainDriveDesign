namespace DomainDriveDesign.Domain.Orders;

public enum OrderStatusEnum
{
    AwaitingApproval = 10,
    BeingPrepared = 20,
    Intransit = 30,
    Delivered = 40,
}
