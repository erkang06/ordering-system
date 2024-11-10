using ordering_system.Properties;
using System.Data;
using System.Drawing.Printing;

void printTicket_PrintPage(object sender, PrintPageEventArgs e, string ticketType)
{
	int ypos = 10;
	int orderID = getOrderID();
	int ticketPaperSizeWidth = Convert.ToInt32(Resources.ticketPaperSizeWidth);
	DataRow orderDataRow = getOrder(orderID);
	// get fonts and sizes
	Font ticketHeaderFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketHeaderFontSize));
	Font ticketItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketItemFontSize));
	Font ticketSetMealFoodItemFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSetMealFoodItemFontSize));
	Font ticketSmallFont = new Font(Resources.ticketFont, Convert.ToInt32(Resources.ticketSmallFontSize));
	// get phone number and order type
	// align ordertype to right, https://stackoverflow.com/q/50299682
	int orderTypeWidth = (int)e.Graphics.MeasureString(currentOrder.orderType, ticketSmallFont).Width;
	e.Graphics.DrawString(currentOrder.orderType, ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - orderTypeWidth, ypos));
	if (currentOrder.orderType != "Counter" && ticketType == "Customer") // kitchen orders dont need addresses and customer names
	{
		e.Graphics.DrawString(customerDataRow["phoneNumber"].ToString(), ticketHeaderFont, Brushes.Black, new Point(10, ypos));
		ypos += (int)ticketHeaderFont.Size + 10;
		// get name or address
		if (currentOrder.orderType == "Collection")
		{
			string customerName = customerDataRow["customerName"].ToString();
			e.Graphics.DrawString(customerName, ticketHeaderFont, Brushes.Black, new Point(10, ypos));
			ypos += (int)ticketHeaderFont.Size + 10;
		}
		else // delivery
		{
			DataRow addressDataRow = getAddress(currentOrder.addressID);
			for (int i = 2; i < 7; i++) // from house number to postcode
			{
				if (addressDataRow[i].ToString() != "")
				{
					e.Graphics.DrawString(addressDataRow[i].ToString(), ticketHeaderFont, Brushes.Black, new Point(10, ypos));
					ypos += (int)ticketHeaderFont.Size + 10;
				}
			}
		}
	}

	// get order date and time
	string orderDateTimeString = Convert.ToDateTime(orderDataRow["orderDate"]).ToString("dd/MM/yyyy") + " " + orderDataRow["orderTime"].ToString();
	e.Graphics.DrawString(orderDateTimeString, ticketSmallFont, Brushes.Black, new Point(10, ypos));
	ypos += (int)ticketSmallFont.Size + 5;
	// break
	e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
	ypos += 20;
	foreach (DataRow runningOrderRow in runningOrderDataTable.Rows) // items
	{
		e.Graphics.DrawString(runningOrderRow["quantity"].ToString(), ticketItemFont, Brushes.Black, new Point(10, ypos));
		// item name
		string itemNameSize = runningOrderRow["itemName"].ToString();
		if (runningOrderRow["size"].ToString() != "") // if item has size add to end of item name
		{
			itemNameSize += " (" + runningOrderRow["size"].ToString()[0] + ")";
		}
		// fit within rectangle in case of overflow
		SizeF itemNameSizeSizeF = e.Graphics.MeasureString(itemNameSize, ticketItemFont, 300);
		e.Graphics.DrawString(itemNameSize, ticketItemFont, Brushes.Black, new RectangleF(new Point(30, ypos), itemNameSizeSizeF));
		// price
		int priceWidth = (int)e.Graphics.MeasureString(runningOrderRow["price"].ToString(), ticketSmallFont).Width;
		e.Graphics.DrawString(runningOrderRow["price"].ToString(), ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - priceWidth, ypos));
		ypos += (int)itemNameSizeSizeF.Height + 5;
		if (runningOrderRow["memo"].ToString() != "") // if theres a memo
		{
			string memo = runningOrderRow["memo"].ToString();
			SizeF memoSizeF = e.Graphics.MeasureString(memo, ticketSmallFont, 250);
			e.Graphics.DrawString(memo, ticketSmallFont, Brushes.Black, new RectangleF(new Point(80, ypos), memoSizeF));
			ypos += (int)memoSizeF.Height + 5;
		}

		if (runningOrderRow["itemType"].ToString() == "setMeal") // set meal needs all items shown
		{
			DataTable setMealFoodItemsDataTable = getSetMealFoodItems(runningOrderRow["itemID"].ToString());
			foreach (DataRow setmealFoodItem in setMealFoodItemsDataTable.Rows)
			{
				e.Graphics.DrawString(setmealFoodItem["quantity"].ToString(), ticketItemFont, Brushes.Black, new Point(50, ypos));
				// get item name from id
				string setMealFoodItemName = getFoodItemName(setmealFoodItem["foodItemID"].ToString());
				// combine name and size
				string setMealFoodItemItemNameSize = setMealFoodItemName + " (" + setmealFoodItem["size"].ToString()[0] + ")";
				// fit within rectangle in case of overflow
				SizeF setMealFoodItemItemNameSizeSizeF = e.Graphics.MeasureString(setMealFoodItemItemNameSize, ticketSetMealFoodItemFont, 250);
				e.Graphics.DrawString(setMealFoodItemItemNameSize, ticketSetMealFoodItemFont, Brushes.Black, new RectangleF(new Point(70, ypos), setMealFoodItemItemNameSizeSizeF));
				ypos += (int)setMealFoodItemItemNameSizeSizeF.Height + 5;
			}
		}
	}
	// break
	e.Graphics.DrawString("*************************************", new Font("Arial", 14), Brushes.Black, new Point(10, ypos));
	ypos += 20;
	// subtotal
	e.Graphics.DrawString("Subtotal:", ticketSmallFont, Brushes.Black, new Point(10, ypos));
	int subtotalWidth = (int)e.Graphics.MeasureString(subtotalPriceLabel.Text, ticketSmallFont).Width;
	e.Graphics.DrawString(subtotalPriceLabel.Text, ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - subtotalWidth, ypos));
	ypos += (int)ticketHeaderFont.Size + 5;
	// delivery charge if delivery
	if (currentOrder.orderType == "Delivery")
	{
		e.Graphics.DrawString("Delivery:", ticketSmallFont, Brushes.Black, new Point(10, ypos));
		int deliveryWidth = (int)e.Graphics.MeasureString(deliveryChargePriceLabel.Text, ticketSmallFont).Width;
		e.Graphics.DrawString(deliveryChargePriceLabel.Text, ticketSmallFont, Brushes.Black, new Point(ticketPaperSizeWidth - deliveryWidth, ypos));
		ypos += (int)ticketHeaderFont.Size + 5;
	}
	// total
	e.Graphics.DrawString("Total:", ticketHeaderFont, Brushes.Black, new Point(10, ypos));
	int totalWidth = (int)e.Graphics.MeasureString(totalPriceLabel.Text, ticketHeaderFont).Width;
	e.Graphics.DrawString(totalPriceLabel.Text, ticketHeaderFont, Brushes.Black, new Point(ticketPaperSizeWidth - totalWidth, ypos));
	ypos += (int)ticketHeaderFont.Size + 20;
	// get estimated time
	e.Graphics.DrawString("Estimated Time:", ticketHeaderFont, Brushes.Black, new Point(10, ypos));
	string estimatedTime = TimeSpan.Parse(orderDataRow["estimatedTime"].ToString()).ToString(@"hh\:mm");
	int estimatedTimeWidth = (int)e.Graphics.MeasureString(estimatedTime, ticketHeaderFont).Width;
	e.Graphics.DrawString(estimatedTime, ticketHeaderFont, Brushes.Black, new Point(ticketPaperSizeWidth - estimatedTimeWidth, ypos));
	ypos += (int)ticketHeaderFont.Size + 20;
	printDocument.DefaultPageSettings.PaperSize = new PaperSize("till", ticketPaperSizeWidth, ypos);
}