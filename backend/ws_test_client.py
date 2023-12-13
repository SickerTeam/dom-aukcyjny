# running: python ws_test_client.py

# - It connects to the specifies address: "ws://localhost:5156/ws"
# - When connected, it sends AuctionId
# - It is able to receive and print out the list of auctions sent by the WebSocketController
# - It is able to receive and print out the BidRegistrationDTO
# - It waits enter is pressed, and then create and sends a new bid_registration_dto where:
#   - AuctionId is the same
#   - UserId is an intiger 1-5
#   - amount is 100 higher than the previous one

import asyncio, json, websockets, random

auction_id = 1
amount = 1000
uri = "ws://localhost:5156/Auction/" + str(auction_id) + "/Bid"

async def connect_and_send_bids(uri, auction_id, amount):
    async with websockets.connect(uri) as websocket:
        print("Connecting with uri: " + uri)

        # Receive and print list of BidDTOs
        response = await websocket.recv()
        bid_dtos = json.loads(response)
        print(f"Received: {bid_dtos}")

        while True:
            # Wait for user to press enter
            input("Press Enter to send a new bid...")

            # Create a new BidRegistrationDTO
            bid_registration_dto = {
                "AuctionId": auction_id,
                "Amount": amount,
                "UserId": random.randint(1, 5)
            }

            # Send BidRegistrationDTO
            await websocket.send(json.dumps(bid_registration_dto))
            print(f"Sent: {bid_registration_dto}")

            # Increase the amount for the next bid
            amount += 100

            # Receive and print new BidDTOs
            response = await websocket.recv()
            new_bid_dto = json.loads(response)
            print(f"Received new bid: {new_bid_dto}")

asyncio.run(connect_and_send_bids(uri, auction_id, amount))