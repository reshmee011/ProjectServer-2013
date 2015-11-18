using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateResourceName
{
    public partial class Form1 : Form
    {
        #region fields and properties
        /// <summary>
        /// wcf for resource binding
        /// </summary>
      //  private static SvcResource.ResourceClient resourceClient;
      //  /// <summary>
      //  /// wcf for custom field binding
      //  /// </summary>
      //  private static SvcCustomFields.CustomFieldsClient customFieldsClient;
      ///// <summary>
      //  /// wcf for lookup binding
      //  /// </summary>
      //  private static SvcLookupTable.LookupTableClient lookupTableClient;
        
        
        #endregion
        
        public Form1()
        {
            InitializeComponent();
        }

//        #region methods
       
        
//        /// <summary>
//        ///  Get the GUID for a Project Server account name. 
//        /// </summary>
//        /// <param name="accountName"></param>
//        /// <returns></returns>
//        public static Guid GetResourceUid(string accountName, string URL)
//        {
//            Guid resourceUid = Guid.Empty;
//            try
//            {
//               // SPSecurity.RunWithElevatedPrivileges(delegate()
//               // {
//               //     using (SPSite site = new SPSite(URL))
//                //    {
//                        ResourceDataSet resourceDs = new ResourceDataSet();

//                        // Filter for the account name, which can be a 
//                        // Windows account or Project Server account.
//                        PSLibrary.Filter filter = new PSLibrary.Filter();
//                        filter.FilterTableName = resourceDs.Resources.TableName;

//                        PSLibrary.Filter.Field accountField = new PSLibrary.Filter.Field(
//                                resourceDs.Resources.TableName,
//                                resourceDs.Resources.RES_NAMEColumn.ColumnName);
//                //WRES_ACCOUNTColumn
//                        filter.Fields.Add(accountField);

//                        PSLibrary.Filter.FieldOperator op = new PSLibrary.Filter.FieldOperator(
//                                PSLibrary.Filter.FieldOperationType.Equal,
//                                resourceDs.Resources.RES_NAMEColumn.ColumnName, accountName);
//                        filter.Criteria = op;

//                        string filterXml = filter.GetXml();

//                        resourceDs = resourceClient.ReadResources(filterXml, false);

//                        // Return the account GUID.
//                        if (resourceDs.Resources.Rows.Count > 0)
//                            resourceUid = (Guid)resourceDs.Resources.Rows[0]["RES_UID"];
//                    }
//               // });
//           // }
//            catch (Exception ex)
//            {
               
//            }
//            return resourceUid;
//        }
//        /// <summary>
//        /// Update Resource Rate
//        /// </summary>
//        /// <param name="resourceUID"></param>
//        /// <param name="rate"></param>
//        /// <param name="effectiveDate"></param>
//        /// <returns>true or false depending whether errors occur</returns>
//        public static string UpdateResourceRate(System.Guid resourceUID, double rate, DateTime effectiveDate)
//        {
//            string statusMessage = string.Empty;
           
//            try
//            {
//                ResourceDataSet resDs = resourceClient.ReadResource(resourceUID);
//                ResourceDataSet.ResourceRatesRow ratesRow = resDs.ResourceRates.NewResourceRatesRow();
//                ratesRow.RES_UID = resourceUID;
//                ratesRow.RES_STD_RATE = rate;
//                ratesRow.RES_OVT_RATE = 0;
//                ratesRow.RES_COST_PER_USE = 0;
//                ratesRow.RES_RATE_EFFECTIVE_DATE = effectiveDate;
//                ratesRow.RES_RATE_TABLE = 0;
//                resDs.ResourceRates.AddResourceRatesRow(ratesRow);
//                resDs.Resources.FindByRES_UID(resourceUID).SetModified();

//                resourceClient.CheckOutResources(new Guid[] { resourceUID });
//                try
//                {
//                    resourceClient.UpdateResources(resDs, false, true); //if update and check in fails,then check in resource..
//                }
//                catch (Exception ex)
//                {
//                    resourceClient.CheckInResources(new Guid[] { resourceUID }, true);
//                }

//            }
//            catch (Exception ex)
//            {
//                statusMessage = string.Format("UpdateResourceRate  - Error = Exception trying to update rate for resource UID = {0} \r\nError {1}", resourceUID.ToString(), ex.Message);
//            }
//            return statusMessage;
//        }

//        /// <summary>
//        /// Gets the custom field information for the required number field and adds it to the resource
//        /// </summary>
//        /// <param name="resourceDs">The <c>ResourceDataSet</c> to add the resource custom field to</param>
//        /// <param name="resourceUid">The resourceUID</param>
//        /// <param name="fieldName">The name of the custom field to set</param>
//        /// <param name="fieldValue">The value to set against the custom field</param>
//        /// <returns></returns>
//        public static string UpdateResourceCustomFieldValue(ResourceDataSet resourceDs, Guid resourceUid, string fieldName, string fieldValue)
//        {
//            string statusMessage = string.Empty;
//            try
//            {
//                string ResourceEntity = PSLibrary.EntityCollection.Entities.ResourceEntity.UniqueId;

//                CustomFieldDataSet customFieldDs = customFieldsClient.ReadCustomFieldsByEntity(new Guid(ResourceEntity));

//                string filter = string.Format("{0}='{1}'", customFieldDs.CustomFields.MD_PROP_NAMEColumn.ColumnName, fieldName);
//                foreach (CustomFieldDataSet.CustomFieldsRow row in customFieldDs.CustomFields.Select(filter))
//                {
//                    filter = string.Format("{0}='{1}' AND {2}='{3}'", resourceDs.ResourceCustomFields.RES_UIDColumn.ColumnName, resourceUid, resourceDs.ResourceCustomFields.MD_PROP_UIDColumn.ColumnName, row.MD_PROP_UID);
//                    ResourceDataSet.ResourceCustomFieldsRow[] customFieldRows = (ResourceDataSet.ResourceCustomFieldsRow[])resourceDs.ResourceCustomFields.Select(filter);

//                    if (customFieldRows.Length > 0)
//                    {
//                        foreach (ResourceDataSet.ResourceCustomFieldsRow customFieldRow in customFieldRows)
//                        {
//                            customFieldRow.TEXT_VALUE = fieldValue;
//                        }
//                    }
//                    else
//                    {
//                        SetResourceCustomFieldValue(resourceDs, row.MD_PROP_UID, resourceUid, fieldValue);
//                    }
//                }
//                customFieldDs.Dispose();
//            }
//            catch (Exception ex)
//            {
//                statusMessage = ex.Message;
//            }
//            return statusMessage;
//        }
//        /// <summary>
//        /// Gets the custom field information for the lookup field and adds it to the resource
//        /// </summary>
//        /// <param name="projectDs">The <c>ResourceDataSet</c> to add the resource custom field to</param>
//        /// <param name="fieldName">The name of the custom field to set</param>
//        /// <param name="fieldValue">The value to set against the custom field</param>
//        public static string UpdateResourceCustomLookupFieldValue(ResourceDataSet resourceDs, Guid resourceUid, string fieldName, string fieldValue)
//        {
//            string strMessage = string.Empty;

//            string ResourceEntity = PSLibrary.EntityCollection.Entities.ResourceEntity.UniqueId;

//            CustomFieldDataSet customFieldDs = customFieldsClient.ReadCustomFieldsByEntity(new Guid(ResourceEntity));

//            string filter = string.Format("{0}='{1}'", customFieldDs.CustomFields.MD_PROP_NAMEColumn.ColumnName, fieldName);

//            //store custom field properties 
//            foreach (CustomFieldDataSet.CustomFieldsRow row in customFieldDs.CustomFields.Select(filter))
//            {
//                Guid valueUid = LookUpValueIdByName(row.MD_PROP_UID, fieldValue);
//                if (valueUid != Guid.Empty)
//                {
//                    filter = string.Format("{0}='{1}' AND {2}='{3}'", resourceDs.ResourceCustomFields.RES_UIDColumn.ColumnName, resourceUid, resourceDs.ResourceCustomFields.MD_PROP_UIDColumn.ColumnName, row.MD_PROP_UID);
//                    ResourceDataSet.ResourceCustomFieldsRow[] customFieldRows = (ResourceDataSet.ResourceCustomFieldsRow[])resourceDs.ResourceCustomFields.Select(filter);

//                    if (customFieldRows.Length > 0)
//                    {
//                        foreach (ResourceDataSet.ResourceCustomFieldsRow customFieldRow in customFieldRows)
//                        {
//                            //compare current value with new value, if the first level is same and only one level is provided, then no update
//                            char[] delimiterChars = { '.' };
//                            string originalValue = GetLookUpFieldTextValue(row.MD_LOOKUP_TABLE_UID, customFieldRow.CODE_VALUE);

//                            string[] valueLevels = fieldValue.Split(delimiterChars);
//                            string[] originalValueLevels = originalValue.Split(delimiterChars);

//                            if (originalValue != fieldValue)
//                            {
//                                customFieldRow.CODE_VALUE = valueUid;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        SetResourceCustomLookUpFieldValue(resourceDs, row.MD_PROP_UID, resourceUid, row.MD_PROP_ID, row.MD_PROP_TYPE_ENUM, valueUid);
//                    }

//                }
//                else
//                {
//                    strMessage = string.Format("Field Value {0} is not a valid value for Field Name {1}", fieldValue, fieldName);

//                }
//            }
//            customFieldDs.Dispose();
//            return strMessage;
//        }

//        /// <summary>
//        /// Sets a string custom field value against a resource
//        /// </summary>
//        /// <param name="resourceDs">The <c>ResourceDataSet</c> to add the values to</param>
//        /// <param name="mdPropUid">The MD_PROP_UID for the resource custom field</param>
//        /// <param name="resourceUid">The <c>RESOURCE_UID</c> for the resource custom field</param>
//        /// <param name="customFieldvalue">The value to write to the resource custom field</param>
//        private static void SetResourceCustomFieldValue(ResourceDataSet resourceDs, Guid mdPropUid, Guid resourceUid, string customFieldString)
//        {
//            ResourceDataSet.ResourceCustomFieldsRow resourceCustomField = resourceDs.ResourceCustomFields.NewResourceCustomFieldsRow();
//            resourceCustomField.RES_UID = resourceUid;
//            resourceCustomField.CUSTOM_FIELD_UID = Guid.NewGuid();
//            resourceCustomField.MD_PROP_UID = mdPropUid;
//            resourceCustomField.TEXT_VALUE = customFieldString;
//            resourceDs.ResourceCustomFields.AddResourceCustomFieldsRow(resourceCustomField);
//        }

//        /// <summary>
//        /// Sets a string custom lookup field value against a resource
//        /// </summary>
//        /// <param name="resourceDs">The <c>ResourceDataSet</c> to add the values to</param>
//        /// <param name="mdPropUid">The MD_PROP_UID for the resource custom field</param>
//        /// <param name="resourceUid">The <c>RESOURCE_UID</c> for the resource custom field</param>
//        /// <param name="customFieldvalue">The value to write to the resource custom field</param>
//        private static void SetResourceCustomLookUpFieldValue(ResourceDataSet resourceDs, Guid mdPropUid, Guid resourceUid, int lookupId, byte lookupByte, Guid valueUid)
//        {
//            ResourceDataSet.ResourceCustomFieldsRow resourceCustomField = resourceDs.ResourceCustomFields.NewResourceCustomFieldsRow();
//            resourceCustomField.RES_UID = resourceUid;
//            resourceCustomField.CUSTOM_FIELD_UID = Guid.NewGuid();
//            resourceCustomField.FIELD_TYPE_ENUM = lookupByte;
//            resourceCustomField.MD_PROP_ID = lookupId;
//            resourceCustomField.MD_PROP_UID = mdPropUid;
//            resourceCustomField.CODE_VALUE = valueUid;
//            resourceDs.ResourceCustomFields.AddResourceCustomFieldsRow(resourceCustomField);
//        }

//        /// <summary>
//        /// Get text from lookup  value id 
//        /// </summary>
//        /// <param name="lookupTableUid"></param>
//        /// <param name="valueUid"></param>
//        /// <returns></returns>
//        private static string GetLookUpFieldTextValue(Guid lookupTableUid, Guid valueUid)
//        {
//            // Set the language code for the lookup table; U.S. English in this case.
//            const int LCID = 1033;
//            string result = string.Empty;

//            // Read the lookup table data.
//            Guid[] lutUids = { lookupTableUid };
//            SvcLookupTable.LookupTableDataSet lutDs =
//                lookupTableClient.ReadLookupTablesByUids(lutUids, false, LCID);

//            // Find the text value in the lookup table tree item that matches the value GUID.
//            for (int i = 0; i < lutDs.LookupTableTrees.Count; i++)
//            {
//                if (lutDs.LookupTableTrees[i].LT_STRUCT_UID == valueUid)
//                {
//                    result = lutDs.LookupTableTrees[i].LT_VALUE_FULL;
//                    break;
//                }
//            }
//            lookupTableClient.Close();
//            return result;
//        }

//        /// <summary>
//        /// Returns the GUID of the Value
//        /// </summary>
//        /// <param name="fieldId">Id of the field</param>
//        /// <param name="nameValue">Name of the Value</param>
//        /// <returns>Guid of the Tree</returns>
//        private static Guid LookUpValueIdByName(Guid fieldId, string nameValue)
//        {
//            CustomFieldDataSet cfResults = customFieldsClient.ReadCustomFieldsByMdPropUids(new Guid[] { fieldId }, false);
//            Guid lookupUid = Guid.NewGuid();
//            Guid valueUid = Guid.Empty;
//            CustomFieldDataSet.CustomFieldsRow cf = null;
//            if (cfResults.Tables[0].Rows.Count > 0)
//            {
//                cf = cfResults.CustomFields[0];
//                lookupUid = cf.MD_LOOKUP_TABLE_UID;
//            }
//            LookupTableDataSet lookupset = lookupTableClient.ReadLookupTablesByUids(new Guid[] { lookupUid }, false, 1031);

//            string filter = string.Format("{0}='{1}'", lookupset.LookupTableTrees.LT_VALUE_FULLColumn.ColumnName, nameValue);
//            foreach (LookupTableDataSet.LookupTableTreesRow treeRow in lookupset.LookupTableTrees.Select(filter))
//            {
//                valueUid = treeRow.LT_STRUCT_UID;
//            }
//            cfResults.Dispose();
//            return valueUid;
//        }

//        /// <summary>
//        /// CreateEndpointAddress
//        /// </summary>
//        /// <param name="pwaUrl"></param>
//        /// <param name="servicePath"></param>
//        private static EndpointAddress CreateEndpointAddress(string pwaUrl, string servicePath)
//        {
//            // create the neccessary WCF bindings to communicate with PSI services
//            string svcUrl = pwaUrl.EndsWith("/") ?
//                string.Format("{0}{1}", pwaUrl, servicePath) :
//                string.Format("{0}/{1}", pwaUrl, servicePath);

//            EndpointAddress address = new EndpointAddress(svcUrl);

//            return address;
//        }

//        // Use the endpoints defined in app.config to configure the client.
//        private static void ConfigClientEndpoints(string pwaUrl)
//        {
//            // The endpoint address is the ProjectServer.svc router for all public PSI calls.
//            EndpointAddress address = CreateEndpointAddress(pwaUrl, "_vti_bin/PSI/ProjectServer.svc");
//            BasicHttpBinding binding = CreateBindings(pwaUrl);

//            resourceClient = new SvcResource.ResourceClient(binding, address);
//            resourceClient.ChannelFactory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
           
//            lookupTableClient = new SvcLookupTable.LookupTableClient(binding, address);
//            lookupTableClient.ChannelFactory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

//            customFieldsClient = new SvcCustomFields.CustomFieldsClient(binding, address);
//            customFieldsClient.ChannelFactory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

//          }
//        /// <summary>
//        /// CreateBindings
//        /// </summary>
//        /// <param name="pwaUrl"></param>
//        /// <returns></returns>
//        private static BasicHttpBinding CreateBindings(string pwaUrl)
//        {
//            // Create a basic binding that can be used for HTTP or HTTPS.
//            BasicHttpBinding binding = null;

//            if (pwaUrl.ToLower().StartsWith("https"))
//            {
//                // Initialize the HTTPS binding.
//                binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
//            }
//            else
//            {
//                // Initialize the HTTP binding.
//                binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
//            }

//            binding.Name = "basicHttpConf";
//            binding.SendTimeout = TimeSpan.MaxValue;
//            binding.MaxReceivedMessageSize = int.MaxValue;
//            binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
//            binding.MessageEncoding = WSMessageEncoding.Text;
//            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;

//            return binding;
//        }
//#endregion
        #region events
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //lblError.Text = "";
            //if (string.IsNullOrEmpty(txtPWAURL.Text))
            //{
            //    throw new ArgumentNullException();
            //}


            //Guid resourceUID = GetResourceUid(txtResource.Text , txtPWAURL.Text);

            //if (resourceUID == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //try
            //{
            //    ResourceDataSet resDs = resourceClient.ReadResource(resourceUID);
            //    if (chkLookupField.Checked)
            //    {
            //        UpdateResourceCustomLookupFieldValue(resDs, resourceUID, txtFieldName.Text, txtFieldVaue.Text);
            //    }
            //    else
            //    {
            //        UpdateResourceCustomFieldValue(resDs, resourceUID, txtFieldName.Text, txtFieldVaue.Text);
            //    }

            //    resourceClient.CheckOutResources(new Guid[] { resourceUID });
            //    //if update fails, need to check in resource
            //    try
            //    {
            //        resourceClient.UpdateResources(resDs, false, true);
            //        lblError.Text = "Saved successfully!";
            //    }
            //    catch(Exception ex)
            //    {
            //        resourceClient.CheckInResources(new Guid[] { resourceUID }, true);
            //        lblError.Text = ex.Message;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
