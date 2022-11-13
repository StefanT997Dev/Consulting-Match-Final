using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace Infrastructure.Security
{
    public class GoogleSheetsDataSender : IDataSender
    {
        const string SPREADSHEET_ID = "1KGAMmW63lxT1Cu8WrdAy_bPOf80ZuLO97V802Wx0mkM";
        const string SHEET_NAME = "Client contact info";

        SpreadsheetsResource.ValuesResource _googleSheetValues;
        public GoogleSheetsDataSender(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }
        public async Task SendDataToGoogleSheetsAsync(RegisterDto registerInfo)
        {
            var range = $"{SHEET_NAME}!A:D";
            var valueRange = new ValueRange
            {
                Values = ItemsMapper.MapToRangeData(registerInfo)
            };
            var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, range);
            appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
            var result = appendRequest.Execute();
        }
    }
}
