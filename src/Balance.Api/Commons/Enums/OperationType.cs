namespace Balance.Api.Commons.Enums;

public enum OperationType
{
    Unknown,
    
    // client ops
    CryptoExternalDeposit = 10,
    CryptoExternalTransfer,
    CryptoInternalTransfer,
    
    BankExternalDeposit = 20,
    BankExternalTransfer,
    BankInternalTransfer,
    
    Exchange = 30,
    CrossExchange,
    
    AcquiringPayment = 40,
    AcquiringPayout,
    AcquiringRefund,
}