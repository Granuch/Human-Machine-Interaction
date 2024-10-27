#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

// Define Wi-Fi credentials
const char* ssid = "POCO M6 Pro";
const char* password = "123456789";

// Create a web server on port 80
ESP8266WebServer server(80);

// Define pin connections
const int led1 = 14;
const int led2 = 16;
const int buttonPin = 12;

// Variables to store the button state
bool buttonPressed = false;

void setup() {
  // Initialize serial for debugging
  Serial.begin(115200);
  
  // Initialize the LED pins as outputs
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  
  // Initialize the button pin as an input with an internal pull-up resistor
  pinMode(buttonPin, INPUT_PULLUP);

  // Set initial LED states to off
  digitalWrite(led1, LOW);
  digitalWrite(led2, LOW);

  // Connect to Wi-Fi
  Serial.print("Connecting to Wi-Fi: ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected.");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  // Setup routes for the web server
  server.on("/", handleRoot);             
  server.on("/led1/on", handleLed1On);    
  server.on("/led1/off", handleLed1Off);  
  server.on("/led2/on", handleLed2On);    
  server.on("/led2/off", handleLed2Off);  
  server.on("/button_state", handleButtonState); 

  // Start the web server
  server.begin();
  Serial.println("HTTP server started.");
}

void loop() {
  // Handle client requests
  server.handleClient();

  // Read the button state
  bool currentButtonState = digitalRead(buttonPin) == HIGH; // LOW means pressed
  if (currentButtonState != buttonPressed) {
    buttonPressed = currentButtonState;
    Serial.print("Button state changed: ");
    Serial.println(buttonPressed ? "Pressed" : "Not pressed");
  }

  // Check for serial input
  if (Serial.available()) {
    String command = Serial.readStringUntil('\n'); // Read command from serial
    handleSerialCommand(command); // Handle the command
  }

  delay(50); // Simple debounce
}

// Handle commands from serial
void handleSerialCommand(String command) {
  if (command == "LED1_ON") {
    digitalWrite(led1, HIGH);
    Serial.println("LED 1 is ON");
  } else if (command == "LED1_OFF") {
    digitalWrite(led1, LOW);
    Serial.println("LED 1 is OFF");
  } else if (command == "LED2_ON") {
    digitalWrite(led2, HIGH);
    Serial.println("LED 2 is ON");
  } else if (command == "LED2_OFF") {
    digitalWrite(led2, LOW);
    Serial.println("LED 2 is OFF");
  } else if (command == "CHECK_BUTTON") {
    Serial.println(digitalRead(buttonPin) == LOW ? "Pressed" : "Not pressed");
  }
}

// Handle the main page
void handleRoot() {
  String html = "<h1>Control LEDs and Check Button</h1>";
  html += "<p><a href=\"/led1/on\">Turn LED 1 on</a></p>";
  html += "<p><a href=\"/led1/off\">Turn LED 1 off</a></p>";
  html += "<p><a href=\"/led2/on\">Turn LED 2 on</a></p>";
  html += "<p><a href=\"/led2/off\">Turn LED 2 off</a></p>";
  html += "<p>Button state: <span id=\"buttonState\">Unknown</span></p>";

  // JavaScript to update button state dynamically
  html += "<script>";
  html += "function updateButtonState() {";
  html += "  var xhr = new XMLHttpRequest();";
  html += "  xhr.onreadystatechange = function() {";
  html += "    if (xhr.readyState == 4 && xhr.status == 200) {";
  html += "      document.getElementById('buttonState').innerHTML = xhr.responseText;";
  html += "    }";
  html += "  };";
  html += "  xhr.open('GET', '/button_state', true);";
  html += "  xhr.send();";
  html += "}";

  html += "setInterval(updateButtonState, 100);";
  html += "</script>";

  server.send(200, "text/html", html);
}

// Handle button state and send it to the web page
void handleButtonState() {
  if (digitalRead(buttonPin) == LOW) {
    server.send(200, "text/plain", "Pressed");
  } else {
    server.send(200, "text/plain", "Not pressed");
  }
}

// Turn LED 1 on
void handleLed1On() {
  digitalWrite(led1, HIGH);
  server.send(200, "text/html", "<h1>LED 1 is ON</h1><a href=\"/\">Go back</a>");
}

// Turn LED 1 off
void handleLed1Off() {
  digitalWrite(led1, LOW);
  server.send(200, "text/html", "<h1>LED 1 is OFF</h1><a href=\"/\">Go back</a>");
}

// Turn LED 2 on
void handleLed2On() {
  digitalWrite(led2, HIGH);
  server.send(200, "text/html", "<h1>LED 2 is ON</h1><a href=\"/\">Go back</a>");
}

// Turn LED 2 off
void handleLed2Off() {
  digitalWrite(led2, LOW);
  server.send(200, "text/html", "<h1>LED 2 is OFF</h1><a href=\"/\">Go back</a>");
}
