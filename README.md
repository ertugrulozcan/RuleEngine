# RuleEngine
Basic .Net Rule Engine 

Sample RuleSet Description;

<RuleSet Name="RuleSet1">
	<RuleSet.Rules>
		<Rule Name="Rule1">
			<Rule.Conditions>
				<Condition Property="Case1" Value="True" Type="Bool" />
				<Condition Property="Case2" Value="True" Type="Bool" />
				<Condition Property="Case3" Value="False" Type="Bool" />
				<Condition Property="Number" Value="12.01" Type="Numeric" Method="Greater" />
				<Condition Property="Floating" Value="123.456" Type="Numeric" />
			</Rule.Conditions>

			<Rule.Setters>
				<Setter Property="TestObject.TestString" Value="Rule Engine" />
				<Setter Property="TestObject.TestBool" Value="True" />
			</Rule.Setters>

			<Rule.Action Method="TestObject.TestMethod">
				<Action.Parameters>
					<Parameter>Test</Parameter>
				</Action.Parameters>
			</Rule.Action>

			<Rule.Callback Method="TestObject.TestMethod">
				<Action.Parameters>
					<Parameter>Test</Parameter>
				</Action.Parameters>
			</Rule.Callback>
		</Rule>
	</RuleSet.Rules>
</RuleSet>
